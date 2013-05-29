using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace Databazovy_Synchronizator
{
    public partial class SideBySideRichTextBox : UserControl
    {
        Hashtable highlightingStyles = new Hashtable();

        #region Scrolling Helpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        protected static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        const int WM_HSCROLL = 276;
        const int WM_VSCROLL = 277;
        const int SB_LINEUP = 0;
        const int SB_LINEDOWN = 1;
        const int SB_THUMBPOSITION = 4;
        const int SB_THUMBTRACK = 5;
        const int SB_TOP = 6;
        const int SB_BOTTOM = 7;
        const int SB_ENDSCROLL = 8;

        private void ApplyScroll(RichTextBox Source, RichTextBox Target, ScrollBarDirection Direction)
        {
            // unhook target from relevant event, otherwise we end up in an infinite loop!
            switch (Direction)
            {
                case ScrollBarDirection.SB_VERT:
                {
                    Target.VScroll -= rtb_VScroll;
                } break;
                case ScrollBarDirection.SB_HORZ:
                {
                    Target.HScroll -= rtb_HScroll;
                } break;
            }

            IntPtr ptrLparam = new IntPtr(0);
            IntPtr ptrWparam;

            // Prepare scroll info struct
            SCROLLINFO si = new SCROLLINFO();
            si.cbSize = (uint)Marshal.SizeOf(si);
            si.fMask = (uint)ScrollInfoMask.SIF_ALL;

            // Get current scroller posion
            GetScrollInfo(Source.Handle, (int)Direction, ref si);

            // if we're tracking, set target to current track position
            if ((si.nTrackPos > 0) || ((si.nTrackPos == 0) && (si.nPos != 0)))
            {
                si.nPos = si.nTrackPos;
            }

            // Reposition scroller
            SetScrollInfo(Target.Handle, (int)Direction, ref si, true);
            ptrWparam = new IntPtr(SB_THUMBTRACK + 0x10000 * si.nPos);
            
            // send the relevant message to the target control, and rehook the event
            switch (Direction)
            {
                case ScrollBarDirection.SB_VERT:
                {
                    SendMessage(Target.Handle, WM_VSCROLL, ptrWparam, ptrLparam);
                    Target.VScroll += new EventHandler(this.rtb_VScroll);
                } break;
                case ScrollBarDirection.SB_HORZ:
                {
                    SendMessage(Target.Handle, WM_HSCROLL, ptrWparam, ptrLparam);
                    Target.HScroll += new EventHandler(this.rtb_HScroll);
                } break;
            }
        }

        private void rtb_VScroll(object sender, EventArgs e)
        {
            // vertical scroll handler
            if (sender is RichTextBox)
            {
                // get the right sender
                RichTextBox senderRtb = sender as RichTextBox;

                // if we're sending from the right
                if (senderRtb == rtbRight)
                {
                    // then synchronise the left with the right
                    ApplyScroll(rtbRight, rtbLeft, ScrollBarDirection.SB_VERT);
                }
                else
                {
                    // otherwise synchronise the right with the left
                    ApplyScroll(rtbLeft, rtbRight, ScrollBarDirection.SB_VERT);
                }
            }
        }

        private void rtb_HScroll(object sender, EventArgs e)
        {
            // horizontal scroll handler
            if (sender is RichTextBox)
            {
                // get the right sender
                RichTextBox senderRtb = sender as RichTextBox;

                // if we're sending from the left
                if (senderRtb == rtbRight)
                {
                    // then synchronise the left with the right
                    ApplyScroll(rtbRight, rtbLeft, ScrollBarDirection.SB_HORZ);
                }
                else
                {
                    // otherwise synchronise the right with the left
                    ApplyScroll(rtbLeft, rtbRight, ScrollBarDirection.SB_HORZ);
                }
            }
        }
        #endregion

        #region Left & Right Text Properties
        string leftText_ = string.Empty;
        string rightText_ = string.Empty;

        public string LeftText
        {
            get
            {
                return leftText_;
            }
            set
            {
                leftText_ = value.Replace("\r", string.Empty);
            }
        }

        public string RightText
        {
            get
            {
                return rightText_;
            }
            set
            {
                rightText_ = value.Replace("\r",string.Empty);
            }
        }
        #endregion

        #region Constructor
        public SideBySideRichTextBox()
        {
            InitializeComponent();

            // hook up to the scroll handlers for the rich text boxes
            this.rtbLeft.VScroll += new EventHandler(this.rtb_VScroll);
            this.rtbLeft.HScroll += new EventHandler(this.rtb_HScroll);
            this.rtbRight.VScroll += new EventHandler(this.rtb_VScroll);
            this.rtbRight.HScroll += new EventHandler(this.rtb_HScroll);

            #region Keyword & Function Initialisation
            // and add the keywords & functions to the hash table
            highlightingStyles.Add("ADD", HighlightColour.Keyword);
            highlightingStyles.Add("ALTER", HighlightColour.Keyword);
            highlightingStyles.Add("AS", HighlightColour.Keyword);
            highlightingStyles.Add("ASC", HighlightColour.Keyword);
            highlightingStyles.Add("AUTHORIZATION", HighlightColour.Keyword);
            highlightingStyles.Add("BACKUP", HighlightColour.Keyword);
            highlightingStyles.Add("BEGIN", HighlightColour.Keyword);
            highlightingStyles.Add("BREAK", HighlightColour.Keyword);
            highlightingStyles.Add("BROWSE", HighlightColour.Keyword);
            highlightingStyles.Add("BULK", HighlightColour.Keyword);
            highlightingStyles.Add("BY", HighlightColour.Keyword);
            highlightingStyles.Add("CASCADE", HighlightColour.Keyword);
            highlightingStyles.Add("CHECK", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKPOINT", HighlightColour.Keyword);
            highlightingStyles.Add("CLOSE", HighlightColour.Keyword);
            highlightingStyles.Add("CLUSTERED", HighlightColour.Keyword);
            highlightingStyles.Add("COLUMN", HighlightColour.Keyword);
            highlightingStyles.Add("COMMIT", HighlightColour.Keyword);
            highlightingStyles.Add("COMMITTED", HighlightColour.Keyword);
            highlightingStyles.Add("COMPUTE", HighlightColour.Keyword);
            highlightingStyles.Add("CONFIRM", HighlightColour.Keyword);
            highlightingStyles.Add("CONSTRAINT", HighlightColour.Keyword);
            highlightingStyles.Add("CONTAINS", HighlightColour.Keyword);
            highlightingStyles.Add("CONTINUE", HighlightColour.Keyword);
            highlightingStyles.Add("CONTROLROW", HighlightColour.Keyword);
            highlightingStyles.Add("CREATE", HighlightColour.Keyword);
            highlightingStyles.Add("CROSS", HighlightColour.Keyword);
            highlightingStyles.Add("CURRENT", HighlightColour.Keyword);
            highlightingStyles.Add("CURRENT_DATE", HighlightColour.Keyword);
            highlightingStyles.Add("CURRENT_TIME", HighlightColour.Keyword);
            highlightingStyles.Add("CURSOR", HighlightColour.Keyword);
            highlightingStyles.Add("DATABASE", HighlightColour.Keyword);
            highlightingStyles.Add("DBCC", HighlightColour.Keyword);
            highlightingStyles.Add("DEALLOCATE", HighlightColour.Keyword);
            highlightingStyles.Add("DECLARE", HighlightColour.Keyword);
            highlightingStyles.Add("DEFAULT", HighlightColour.Keyword);
            highlightingStyles.Add("DELETE", HighlightColour.Keyword);
            highlightingStyles.Add("DENY", HighlightColour.Keyword);
            highlightingStyles.Add("DESC", HighlightColour.Keyword);
            highlightingStyles.Add("DISK", HighlightColour.Keyword);
            highlightingStyles.Add("DISTINCT", HighlightColour.Keyword);
            highlightingStyles.Add("DISTRIBUTED", HighlightColour.Keyword);
            highlightingStyles.Add("DROP", HighlightColour.Keyword);
            highlightingStyles.Add("DUMMY", HighlightColour.Keyword);
            highlightingStyles.Add("DUMP", HighlightColour.Keyword);
            highlightingStyles.Add("ELSE", HighlightColour.Keyword);
            highlightingStyles.Add("ERRLVL", HighlightColour.Keyword);
            highlightingStyles.Add("ERROREXIT", HighlightColour.Keyword);
            highlightingStyles.Add("ESCAPE", HighlightColour.Keyword);
            highlightingStyles.Add("EXCEPT", HighlightColour.Keyword);
            highlightingStyles.Add("EXEC", HighlightColour.Keyword);
            highlightingStyles.Add("EXECUTE", HighlightColour.Keyword);
            highlightingStyles.Add("EXIT", HighlightColour.Keyword);
            highlightingStyles.Add("FETCH", HighlightColour.Keyword);
            highlightingStyles.Add("FILE", HighlightColour.Keyword);
            highlightingStyles.Add("FILLFACTOR", HighlightColour.Keyword);
            highlightingStyles.Add("FLOPPY", HighlightColour.Keyword);
            highlightingStyles.Add("FOR", HighlightColour.Keyword);
            highlightingStyles.Add("FOREIGN", HighlightColour.Keyword);
            highlightingStyles.Add("FREETEXT", HighlightColour.Keyword);
            highlightingStyles.Add("FROM", HighlightColour.Keyword);
            highlightingStyles.Add("FULL", HighlightColour.Keyword);
            highlightingStyles.Add("FUNCTION", HighlightColour.Keyword);
            highlightingStyles.Add("GO", HighlightColour.Keyword);
            highlightingStyles.Add("GOTO", HighlightColour.Keyword);
            highlightingStyles.Add("GRANT", HighlightColour.Keyword);
            highlightingStyles.Add("GROUP", HighlightColour.Keyword);
            highlightingStyles.Add("HAVING", HighlightColour.Keyword);
            highlightingStyles.Add("HOLDLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("IDENTITY_INSERT", HighlightColour.Keyword);
            highlightingStyles.Add("IDENTITYCOL", HighlightColour.Keyword);
            highlightingStyles.Add("IF", HighlightColour.Keyword);
            highlightingStyles.Add("INDEX", HighlightColour.Keyword);
            highlightingStyles.Add("INNER", HighlightColour.Keyword);
            highlightingStyles.Add("INSERT", HighlightColour.Keyword);
            highlightingStyles.Add("INTERSECT", HighlightColour.Keyword);
            highlightingStyles.Add("INTO", HighlightColour.Keyword);
            highlightingStyles.Add("IS", HighlightColour.Keyword);
            highlightingStyles.Add("ISOLATION", HighlightColour.Keyword);
            highlightingStyles.Add("JOIN", HighlightColour.Keyword);
            highlightingStyles.Add("KEY", HighlightColour.Keyword);
            highlightingStyles.Add("KILL", HighlightColour.Keyword);
            highlightingStyles.Add("LEVEL", HighlightColour.Keyword);
            highlightingStyles.Add("LINENO", HighlightColour.Keyword);
            highlightingStyles.Add("LOAD", HighlightColour.Keyword);
            highlightingStyles.Add("MIRROREXIT", HighlightColour.Keyword);
            highlightingStyles.Add("NEXT", HighlightColour.Keyword);
            highlightingStyles.Add("NOCHECK", HighlightColour.Keyword);
            highlightingStyles.Add("NONCLUSTERED", HighlightColour.Keyword);
            highlightingStyles.Add("NULL", HighlightColour.Keyword);
            highlightingStyles.Add("OF", HighlightColour.Keyword);
            highlightingStyles.Add("OFF", HighlightColour.Keyword);
            highlightingStyles.Add("OFFSETS", HighlightColour.Keyword);
            highlightingStyles.Add("ON", HighlightColour.Keyword);
            highlightingStyles.Add("ONCE", HighlightColour.Keyword);
            highlightingStyles.Add("ONLY", HighlightColour.Keyword);
            highlightingStyles.Add("OPEN", HighlightColour.Keyword);
            highlightingStyles.Add("OPENDATASOURCE", HighlightColour.Keyword);
            highlightingStyles.Add("OPTION", HighlightColour.Keyword);
            highlightingStyles.Add("ORDER", HighlightColour.Keyword);
            highlightingStyles.Add("OUTER", HighlightColour.Keyword);
            highlightingStyles.Add("OVER", HighlightColour.Keyword);
            highlightingStyles.Add("PERCENT", HighlightColour.Keyword);
            highlightingStyles.Add("PERM", HighlightColour.Keyword);
            highlightingStyles.Add("PERMANENT", HighlightColour.Keyword);
            highlightingStyles.Add("PIPE", HighlightColour.Keyword);
            highlightingStyles.Add("PLAN", HighlightColour.Keyword);
            highlightingStyles.Add("PREPARE", HighlightColour.Keyword);
            highlightingStyles.Add("PRINT", HighlightColour.Keyword);
            highlightingStyles.Add("PRIVILEGES", HighlightColour.Keyword);
            highlightingStyles.Add("PROC", HighlightColour.Keyword);
            highlightingStyles.Add("PROCEDURE", HighlightColour.Keyword);
            highlightingStyles.Add("PROCESSEXIT", HighlightColour.Keyword);
            highlightingStyles.Add("PUBLIC", HighlightColour.Keyword);
            highlightingStyles.Add("RAISERROR", HighlightColour.Keyword);
            highlightingStyles.Add("READ", HighlightColour.Keyword);
            highlightingStyles.Add("READTEXT", HighlightColour.Keyword);
            highlightingStyles.Add("RECONFIGURE", HighlightColour.Keyword);
            highlightingStyles.Add("REFERENCES", HighlightColour.Keyword);
            highlightingStyles.Add("REPEATABLE", HighlightColour.Keyword);
            highlightingStyles.Add("REPLICATION", HighlightColour.Keyword);
            highlightingStyles.Add("RESTORE", HighlightColour.Keyword);
            highlightingStyles.Add("RESTRICT", HighlightColour.Keyword);
            highlightingStyles.Add("RETURNS", HighlightColour.Keyword);
            highlightingStyles.Add("RETURN", HighlightColour.Keyword);
            highlightingStyles.Add("REVOKE", HighlightColour.Keyword);
            highlightingStyles.Add("ROLLBACK", HighlightColour.Keyword);
            highlightingStyles.Add("ROWCOUNT", HighlightColour.Keyword);
            highlightingStyles.Add("ROWGUIDCOL", HighlightColour.Keyword);
            highlightingStyles.Add("RULE", HighlightColour.Keyword);
            highlightingStyles.Add("SAVE", HighlightColour.Keyword);
            highlightingStyles.Add("SCHEMA", HighlightColour.Keyword);
            highlightingStyles.Add("SELECT", HighlightColour.Keyword);
            highlightingStyles.Add("SERIALIZABLE", HighlightColour.Keyword);
            highlightingStyles.Add("SET", HighlightColour.Keyword);
            highlightingStyles.Add("SETUSER", HighlightColour.Keyword);
            highlightingStyles.Add("SHUTDOWN", HighlightColour.Keyword);
            highlightingStyles.Add("STATISTICS", HighlightColour.Keyword);
            highlightingStyles.Add("TABLE", HighlightColour.Keyword);
            highlightingStyles.Add("TAPE", HighlightColour.Keyword);
            highlightingStyles.Add("TEMP", HighlightColour.Keyword);
            highlightingStyles.Add("TEMPORARY", HighlightColour.Keyword);
            highlightingStyles.Add("TEXTSIZE", HighlightColour.Keyword);
            highlightingStyles.Add("THEN", HighlightColour.Keyword);
            highlightingStyles.Add("TO", HighlightColour.Keyword);
            highlightingStyles.Add("TOP", HighlightColour.Keyword);
            highlightingStyles.Add("TRAN", HighlightColour.Keyword);
            highlightingStyles.Add("TRANSACTION", HighlightColour.Keyword);
            highlightingStyles.Add("TRIGGER", HighlightColour.Keyword);
            highlightingStyles.Add("TRUNCATE", HighlightColour.Keyword);
            highlightingStyles.Add("TSEQUAL", HighlightColour.Keyword);
            highlightingStyles.Add("UNCOMMITTED", HighlightColour.Keyword);
            highlightingStyles.Add("UNION", HighlightColour.Keyword);
            highlightingStyles.Add("UNIQUE", HighlightColour.Keyword);
            highlightingStyles.Add("UPDATE", HighlightColour.Keyword);
            highlightingStyles.Add("UPDATETEXT", HighlightColour.Keyword);
            highlightingStyles.Add("USE", HighlightColour.Keyword);
            highlightingStyles.Add("VALUES", HighlightColour.Keyword);
            highlightingStyles.Add("VIEW", HighlightColour.Keyword);
            highlightingStyles.Add("WAITFOR", HighlightColour.Keyword);
            highlightingStyles.Add("WHEN", HighlightColour.Keyword);
            highlightingStyles.Add("WHERE", HighlightColour.Keyword);
            highlightingStyles.Add("WHILE", HighlightColour.Keyword);
            highlightingStyles.Add("WITH", HighlightColour.Keyword);
            highlightingStyles.Add("WORK", HighlightColour.Keyword);
            highlightingStyles.Add("WRITETEXT", HighlightColour.Keyword);
            highlightingStyles.Add("SYNONYM", HighlightColour.Keyword);
            highlightingStyles.Add("PRIMARY", HighlightColour.Keyword);
            highlightingStyles.Add("DATEFIRST", HighlightColour.Keyword);
            highlightingStyles.Add("DATEFORMAT", HighlightColour.Keyword);
            highlightingStyles.Add("DEADLOCK_PRIORITY", HighlightColour.Keyword);
            highlightingStyles.Add("LOCK_TIMEOUT", HighlightColour.Keyword);
            highlightingStyles.Add("CONCAT_NULL_YIELDS_NULL", HighlightColour.Keyword);
            highlightingStyles.Add("LANGUAGE", HighlightColour.Keyword);
            highlightingStyles.Add("CURSOR_CLOSE_ON_COMMIT", HighlightColour.Keyword);
            highlightingStyles.Add("DISABLE_DEF_CNST_CHK", HighlightColour.Keyword);
            highlightingStyles.Add("PROCID", HighlightColour.Keyword);
            highlightingStyles.Add("FIPS_FLAGGER", HighlightColour.Keyword);
            highlightingStyles.Add("QUOTED_IDENTIFIER", HighlightColour.Keyword);
            highlightingStyles.Add("ARITHABORT", HighlightColour.Keyword);
            highlightingStyles.Add("NUMERIC_ROUNDABORT", HighlightColour.Keyword);
            highlightingStyles.Add("ARITHIGNORE", HighlightColour.Keyword);
            highlightingStyles.Add("PARSEONLY", HighlightColour.Keyword);
            highlightingStyles.Add("FMTONLY", HighlightColour.Keyword);
            highlightingStyles.Add("QUERY_GOVERNOR_COST_LIMIT", HighlightColour.Keyword);
            highlightingStyles.Add("NOCOUNT", HighlightColour.Keyword);
            highlightingStyles.Add("NOEXEC", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_DEFAULTS", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_NULLS", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_NULL_DFLT_OFF", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_PADDING", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_NULL_DFLT_ON", HighlightColour.Keyword);
            highlightingStyles.Add("ANSI_WARNINGS", HighlightColour.Keyword);
            highlightingStyles.Add("FORCEPLAN", HighlightColour.Keyword);
            highlightingStyles.Add("IO", HighlightColour.Keyword);
            highlightingStyles.Add("SHOWPLAN_ALL", HighlightColour.Keyword);
            highlightingStyles.Add("PROFILE", HighlightColour.Keyword);
            highlightingStyles.Add("SHOWPLAN_TEXT", HighlightColour.Keyword);
            highlightingStyles.Add("TIME", HighlightColour.Keyword);
            highlightingStyles.Add("IMPLICIT_TRANSACTIONS", HighlightColour.Keyword);
            highlightingStyles.Add("REMOTE_PROC_TRANSACTIONS", HighlightColour.Keyword);
            highlightingStyles.Add("XACT_ABORT", HighlightColour.Keyword);
            highlightingStyles.Add("NOEXPAND", HighlightColour.Keyword);
            highlightingStyles.Add("KEEPIDENTITY", HighlightColour.Keyword);
            highlightingStyles.Add("KEEPDEFAULTS", HighlightColour.Keyword);
            highlightingStyles.Add("FASTFIRSTROW", HighlightColour.Keyword);
            highlightingStyles.Add("IGNORE_CONSTRAINTS", HighlightColour.Keyword);
            highlightingStyles.Add("IGNORE_TRIGGERS", HighlightColour.Keyword);
            highlightingStyles.Add("NOLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("NOWAIT", HighlightColour.Keyword);
            highlightingStyles.Add("PAGLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("READCOMMITTED", HighlightColour.Keyword);
            highlightingStyles.Add("READCOMMITTEDLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("READPAST", HighlightColour.Keyword);
            highlightingStyles.Add("READUNCOMMITTED", HighlightColour.Keyword);
            highlightingStyles.Add("REPEATABLEREAD", HighlightColour.Keyword);
            highlightingStyles.Add("ROWLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("TABLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("TABLOCKX", HighlightColour.Keyword);
            highlightingStyles.Add("UPDLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("XLOCK", HighlightColour.Keyword);
            highlightingStyles.Add("HASH", HighlightColour.Keyword);
            highlightingStyles.Add("MERGE", HighlightColour.Keyword);
            highlightingStyles.Add("CONCAT", HighlightColour.Keyword);
            highlightingStyles.Add("LOOP", HighlightColour.Keyword);
            highlightingStyles.Add("FAST", HighlightColour.Keyword);
            highlightingStyles.Add("FORCE", HighlightColour.Keyword);
            highlightingStyles.Add("MAXDOP", HighlightColour.Keyword);
            highlightingStyles.Add("OPTIMIZE", HighlightColour.Keyword);
            highlightingStyles.Add("PARAMETERIZATION", HighlightColour.Keyword);
            highlightingStyles.Add("SIMPLE", HighlightColour.Keyword);
            highlightingStyles.Add("FORCED", HighlightColour.Keyword);
            highlightingStyles.Add("RECOMPILE", HighlightColour.Keyword);
            highlightingStyles.Add("ROBUST", HighlightColour.Keyword);
            highlightingStyles.Add("KEEP", HighlightColour.Keyword);
            highlightingStyles.Add("KEEPFIXED", HighlightColour.Keyword);
            highlightingStyles.Add("EXPAND", HighlightColour.Keyword);
            highlightingStyles.Add("VIEWS", HighlightColour.Keyword);
            highlightingStyles.Add("MAXRECURSION", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKALLOC", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKCATALOG", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKCONSTRAINTS", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKDB", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKFILEGROUP", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKIDENT", HighlightColour.Keyword);
            highlightingStyles.Add("CHECKTABLE", HighlightColour.Keyword);
            highlightingStyles.Add("CLEANTABLE", HighlightColour.Keyword);
            highlightingStyles.Add("CONCURRENCYVIOLATION", HighlightColour.Keyword);
            highlightingStyles.Add("DBREINDEX", HighlightColour.Keyword);
            highlightingStyles.Add("DBREPAIR", HighlightColour.Keyword);
            highlightingStyles.Add("DROPCLEANBUFFERS", HighlightColour.Keyword);
            highlightingStyles.Add("FREEPROCCACHE", HighlightColour.Keyword);
            highlightingStyles.Add("FREESESSIONCACHE", HighlightColour.Keyword);
            highlightingStyles.Add("FREESYSTEMCACHE", HighlightColour.Keyword);
            highlightingStyles.Add("HELP", HighlightColour.Keyword);
            highlightingStyles.Add("INDEXDEFRAG", HighlightColour.Keyword);
            highlightingStyles.Add("INPUTBUFFER", HighlightColour.Keyword);
            highlightingStyles.Add("OPENTRAN", HighlightColour.Keyword);
            highlightingStyles.Add("OUTPUTBUFFER", HighlightColour.Keyword);
            highlightingStyles.Add("PINTABLE", HighlightColour.Keyword);
            highlightingStyles.Add("PROCCACHE", HighlightColour.Keyword);
            highlightingStyles.Add("SHOW_STATISTICS", HighlightColour.Keyword);
            highlightingStyles.Add("SHOWCONTIG", HighlightColour.Keyword);
            highlightingStyles.Add("SHRINKDATABASE", HighlightColour.Keyword);
            highlightingStyles.Add("SHRINKFILE", HighlightColour.Keyword);
            highlightingStyles.Add("SQLPERF", HighlightColour.Keyword);
            highlightingStyles.Add("TRACEOFF", HighlightColour.Keyword);
            highlightingStyles.Add("TRACEON", HighlightColour.Keyword);
            highlightingStyles.Add("TRACESTATUS", HighlightColour.Keyword);
            highlightingStyles.Add("UNPINTABLE", HighlightColour.Keyword);
            highlightingStyles.Add("UPDATEUSAGE", HighlightColour.Keyword);
            highlightingStyles.Add("USEROPTIONS", HighlightColour.Keyword);
            highlightingStyles.Add("DELAY", HighlightColour.Keyword);
            highlightingStyles.Add("ABS", HighlightColour.Function);
            highlightingStyles.Add("ACOS", HighlightColour.Function);
            highlightingStyles.Add("APP_NAME", HighlightColour.Function);
            highlightingStyles.Add("ASCII", HighlightColour.Function);
            highlightingStyles.Add("ASIN", HighlightColour.Function);
            highlightingStyles.Add("ATAN", HighlightColour.Function);
            highlightingStyles.Add("ATN2", HighlightColour.Function);
            highlightingStyles.Add("AVG", HighlightColour.Function);
            highlightingStyles.Add("CASE", HighlightColour.Function);
            highlightingStyles.Add("CAST", HighlightColour.Function);
            highlightingStyles.Add("CEILING", HighlightColour.Function);
            highlightingStyles.Add("CHARINDEX", HighlightColour.Function);
            highlightingStyles.Add("COALESCE", HighlightColour.Function);
            highlightingStyles.Add("COL_LENGTH", HighlightColour.Function);
            highlightingStyles.Add("COL_NAME", HighlightColour.Function);
            highlightingStyles.Add("COLUMNPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("CONTAINSTABLE", HighlightColour.Function);
            highlightingStyles.Add("CONVERT", HighlightColour.Function);
            highlightingStyles.Add("COS", HighlightColour.Function);
            highlightingStyles.Add("COT", HighlightColour.Function);
            highlightingStyles.Add("COUNT", HighlightColour.Function);
            highlightingStyles.Add("CURRENT_TIMESTAMP", HighlightColour.Function);
            highlightingStyles.Add("CURRENT_USER", HighlightColour.Function);
            highlightingStyles.Add("CURSOR_STATUS", HighlightColour.Function);
            highlightingStyles.Add("DATABASEPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("DATALENGTH", HighlightColour.Function);
            highlightingStyles.Add("DATEADD", HighlightColour.Function);
            highlightingStyles.Add("DATEDIFF", HighlightColour.Function);
            highlightingStyles.Add("DATENAME", HighlightColour.Function);
            highlightingStyles.Add("DATEPART", HighlightColour.Function);
            highlightingStyles.Add("DAY", HighlightColour.Function);
            highlightingStyles.Add("DB_ID", HighlightColour.Function);
            highlightingStyles.Add("DB_NAME", HighlightColour.Function);
            highlightingStyles.Add("DEGREES", HighlightColour.Function);
            highlightingStyles.Add("DIFFERENCE", HighlightColour.Function);
            highlightingStyles.Add("EXP", HighlightColour.Function);
            highlightingStyles.Add("FILE_ID", HighlightColour.Function);
            highlightingStyles.Add("FILE_NAME", HighlightColour.Function);
            highlightingStyles.Add("FILEGROUP_ID", HighlightColour.Function);
            highlightingStyles.Add("FILEGROUP_NAME", HighlightColour.Function);
            highlightingStyles.Add("FILEGROUPPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("FILEPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("FLOOR", HighlightColour.Function);
            highlightingStyles.Add("FORMATMESSAGE", HighlightColour.Function);
            highlightingStyles.Add("FREETEXTTABLE", HighlightColour.Function);
            highlightingStyles.Add("FULLTEXTCATALOGPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("FULLTEXTSERVICEPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("GETANSINULL", HighlightColour.Function);
            highlightingStyles.Add("GETDATE", HighlightColour.Function);
            highlightingStyles.Add("GROUPING", HighlightColour.Function);
            highlightingStyles.Add("HOST_ID", HighlightColour.Function);
            highlightingStyles.Add("HOST_NAME", HighlightColour.Function);
            highlightingStyles.Add("IDENT_INCR", HighlightColour.Function);
            highlightingStyles.Add("IDENT_SEED", HighlightColour.Function);
            highlightingStyles.Add("IDENT_CURRENT", HighlightColour.Function);
            highlightingStyles.Add("IDENTITY", HighlightColour.Function);
            highlightingStyles.Add("INDEX_COL", HighlightColour.Function);
            highlightingStyles.Add("INDEXPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("IS_MEMBER", HighlightColour.Function);
            highlightingStyles.Add("IS_SRVROLEMEMBER", HighlightColour.Function);
            highlightingStyles.Add("ISDATE", HighlightColour.Function);
            highlightingStyles.Add("ISNULL", HighlightColour.Function);
            highlightingStyles.Add("ISNUMERIC", HighlightColour.Function);
            highlightingStyles.Add("LEFT", HighlightColour.Function);
            highlightingStyles.Add("LEN", HighlightColour.Function);
            highlightingStyles.Add("LOG", HighlightColour.Function);
            highlightingStyles.Add("LOG10", HighlightColour.Function);
            highlightingStyles.Add("LOWER", HighlightColour.Function);
            highlightingStyles.Add("LTRIM", HighlightColour.Function);
            highlightingStyles.Add("MAX", HighlightColour.Function);
            highlightingStyles.Add("MIN", HighlightColour.Function);
            highlightingStyles.Add("MONTH", HighlightColour.Function);
            highlightingStyles.Add("NEWID", HighlightColour.Function);
            highlightingStyles.Add("NULLIF", HighlightColour.Function);
            highlightingStyles.Add("OBJECT_ID", HighlightColour.Function);
            highlightingStyles.Add("OBJECT_NAME", HighlightColour.Function);
            highlightingStyles.Add("OBJECTPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("OPENQUERY", HighlightColour.Function);
            highlightingStyles.Add("OPENROWSET", HighlightColour.Function);
            highlightingStyles.Add("PARSENAME", HighlightColour.Function);
            highlightingStyles.Add("PATINDEX", HighlightColour.Function);
            highlightingStyles.Add("PERMISSIONS", HighlightColour.Function);
            highlightingStyles.Add("PI", HighlightColour.Function);
            highlightingStyles.Add("POWER", HighlightColour.Function);
            highlightingStyles.Add("QUOTENAME", HighlightColour.Function);
            highlightingStyles.Add("RADIANS", HighlightColour.Function);
            highlightingStyles.Add("RAND", HighlightColour.Function);
            highlightingStyles.Add("REPLACE", HighlightColour.Function);
            highlightingStyles.Add("REPLICATE", HighlightColour.Function);
            highlightingStyles.Add("REVERSE", HighlightColour.Function);
            highlightingStyles.Add("RIGHT", HighlightColour.Function);
            highlightingStyles.Add("ROUND", HighlightColour.Function);
            highlightingStyles.Add("RTRIM", HighlightColour.Function);
            highlightingStyles.Add("SCOPE_IDENTITY", HighlightColour.Function);
            highlightingStyles.Add("SESSION_USER", HighlightColour.Function);
            highlightingStyles.Add("SIGN", HighlightColour.Function);
            highlightingStyles.Add("SIN", HighlightColour.Function);
            highlightingStyles.Add("SOUNDEX", HighlightColour.Function);
            highlightingStyles.Add("SPACE", HighlightColour.Function);
            highlightingStyles.Add("SQRT", HighlightColour.Function);
            highlightingStyles.Add("SQUARE", HighlightColour.Function);
            highlightingStyles.Add("STATS_DATE", HighlightColour.Function);
            highlightingStyles.Add("STDEV", HighlightColour.Function);
            highlightingStyles.Add("STDEVP", HighlightColour.Function);
            highlightingStyles.Add("STR", HighlightColour.Function);
            highlightingStyles.Add("STUFF", HighlightColour.Function);
            highlightingStyles.Add("SUBSTRING", HighlightColour.Function);
            highlightingStyles.Add("SUM", HighlightColour.Function);
            highlightingStyles.Add("SUSER_ID", HighlightColour.Function);
            highlightingStyles.Add("SUSER_NAME", HighlightColour.Function);
            highlightingStyles.Add("SUSER_SID", HighlightColour.Function);
            highlightingStyles.Add("SUSER_SNAME", HighlightColour.Function);
            highlightingStyles.Add("SYSTEM_USER", HighlightColour.Function);
            highlightingStyles.Add("TAN", HighlightColour.Function);
            highlightingStyles.Add("TEXTPTR", HighlightColour.Function);
            highlightingStyles.Add("TEXTVALID", HighlightColour.Function);
            highlightingStyles.Add("TYPEPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("UNICODE", HighlightColour.Function);
            highlightingStyles.Add("UPPER", HighlightColour.Function);
            highlightingStyles.Add("USER", HighlightColour.Function);
            highlightingStyles.Add("USER_ID", HighlightColour.Function);
            highlightingStyles.Add("USER_NAME", HighlightColour.Function);
            highlightingStyles.Add("VAR", HighlightColour.Function);
            highlightingStyles.Add("VARP", HighlightColour.Function);
            highlightingStyles.Add("YEAR", HighlightColour.Function);
            highlightingStyles.Add("SERVERPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("SESSIONPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("SCHEMA_NAME", HighlightColour.Function);
            highlightingStyles.Add("NTILE", HighlightColour.Function);
            highlightingStyles.Add("SQL_VARIANT_PROPERTY", HighlightColour.Function);
            highlightingStyles.Add("TYPE_ID", HighlightColour.Function);
            highlightingStyles.Add("FILE_IDEX", HighlightColour.Function);
            highlightingStyles.Add("INDEXKEY_PROPERTY", HighlightColour.Function);
            highlightingStyles.Add("DATABASEPROPERTYEX", HighlightColour.Function);
            highlightingStyles.Add("OBJECTPROPERTYEX", HighlightColour.Function);
            highlightingStyles.Add("SCHEMA_ID", HighlightColour.Function);
            highlightingStyles.Add("CHECKSUM_AGG", HighlightColour.Function);
            highlightingStyles.Add("TYPE_NAME", HighlightColour.Function);
            highlightingStyles.Add("CHECKSUM", HighlightColour.Function);
            highlightingStyles.Add("COLLATIONPROPERTY", HighlightColour.Function);
            highlightingStyles.Add("COUNT_BIG", HighlightColour.Function);
            highlightingStyles.Add("@@CONNECTIONS", HighlightColour.Function);
            highlightingStyles.Add("@@CPU_BUSY", HighlightColour.Function);
            highlightingStyles.Add("@@CURSOR_ROWS", HighlightColour.Function);
            highlightingStyles.Add("@@DATEFIRST", HighlightColour.Function);
            highlightingStyles.Add("@@DBTS", HighlightColour.Function);
            highlightingStyles.Add("@@ERROR", HighlightColour.Function);
            highlightingStyles.Add("@@FETCH_STATUS", HighlightColour.Function);
            highlightingStyles.Add("@@IDENTITY", HighlightColour.Function);
            highlightingStyles.Add("@@IDLE", HighlightColour.Function);
            highlightingStyles.Add("@@IO_BUSY", HighlightColour.Function);
            highlightingStyles.Add("@@LANGID", HighlightColour.Function);
            highlightingStyles.Add("@@LANGUAGE", HighlightColour.Function);
            highlightingStyles.Add("@@LOCK_TIMEOUT", HighlightColour.Function);
            highlightingStyles.Add("@@MAX_CONNECTIONS", HighlightColour.Function);
            highlightingStyles.Add("@@MAX_PRECISION", HighlightColour.Function);
            highlightingStyles.Add("@@NESTLEVEL", HighlightColour.Function);
            highlightingStyles.Add("@@OPTIONS", HighlightColour.Function);
            highlightingStyles.Add("@@PACK_RECEIVED", HighlightColour.Function);
            highlightingStyles.Add("@@PACK_SENT", HighlightColour.Function);
            highlightingStyles.Add("@@PACKET_ERRORS", HighlightColour.Function);
            highlightingStyles.Add("@@PROCID", HighlightColour.Function);
            highlightingStyles.Add("@@REMSERVER", HighlightColour.Function);
            highlightingStyles.Add("@@ROWCOUNT", HighlightColour.Function);
            highlightingStyles.Add("@@SERVERNAME", HighlightColour.Function);
            highlightingStyles.Add("@@SERVICENAME", HighlightColour.Function);
            highlightingStyles.Add("@@SPID", HighlightColour.Function);
            highlightingStyles.Add("@@TEXTSIZE", HighlightColour.Function);
            highlightingStyles.Add("@@TIMETICKS", HighlightColour.Function);
            highlightingStyles.Add("@@TOTAL_ERRORS", HighlightColour.Function);
            highlightingStyles.Add("@@TOTAL_READ", HighlightColour.Function);
            highlightingStyles.Add("@@TOTAL_WRITE", HighlightColour.Function);
            highlightingStyles.Add("@@TRANCOUNT", HighlightColour.Function);
            highlightingStyles.Add("@@VERSION", HighlightColour.Function);
            highlightingStyles.Add("-", HighlightColour.Operator);
            highlightingStyles.Add("*", HighlightColour.Operator);
            highlightingStyles.Add("/", HighlightColour.Operator);
            highlightingStyles.Add("%", HighlightColour.Operator);
            highlightingStyles.Add("~", HighlightColour.Operator);
            highlightingStyles.Add("&", HighlightColour.Operator);
            highlightingStyles.Add("|", HighlightColour.Operator);
            highlightingStyles.Add("^", HighlightColour.Operator);
            highlightingStyles.Add("!", HighlightColour.Operator);
            highlightingStyles.Add("=", HighlightColour.Operator);
            highlightingStyles.Add(">", HighlightColour.Operator);
            highlightingStyles.Add("<", HighlightColour.Operator);
            highlightingStyles.Add("ALL", HighlightColour.Operator);
            highlightingStyles.Add("AND", HighlightColour.Operator);
            highlightingStyles.Add("ANY", HighlightColour.Operator);
            highlightingStyles.Add("BETWEEN", HighlightColour.Operator);
            highlightingStyles.Add("EXISTS", HighlightColour.Operator);
            highlightingStyles.Add("IN", HighlightColour.Operator);
            highlightingStyles.Add("LIKE", HighlightColour.Operator);
            highlightingStyles.Add("NOT", HighlightColour.Operator);
            highlightingStyles.Add("OR", HighlightColour.Operator);
            highlightingStyles.Add("SOME", HighlightColour.Operator);
            highlightingStyles.Add("IMAGE", HighlightColour.Datatype);
            highlightingStyles.Add("TEXT", HighlightColour.Datatype);
            highlightingStyles.Add("UNIQUEIDENTIFIER", HighlightColour.Datatype);
            highlightingStyles.Add("TINYINT", HighlightColour.Datatype);
            highlightingStyles.Add("SMALLINT", HighlightColour.Datatype);
            highlightingStyles.Add("INT", HighlightColour.Datatype);
            highlightingStyles.Add("SMALLDATETIME", HighlightColour.Datatype);
            highlightingStyles.Add("REAL", HighlightColour.Datatype);
            highlightingStyles.Add("MONEY", HighlightColour.Datatype);
            highlightingStyles.Add("DATETIME", HighlightColour.Datatype);
            highlightingStyles.Add("FLOAT", HighlightColour.Datatype);
            highlightingStyles.Add("SQL_VARIANT", HighlightColour.Datatype);
            highlightingStyles.Add("NTEXT", HighlightColour.Datatype);
            highlightingStyles.Add("BIT", HighlightColour.Datatype);
            highlightingStyles.Add("DECIMAL", HighlightColour.Datatype);
            highlightingStyles.Add("NUMERIC", HighlightColour.Datatype);
            highlightingStyles.Add("SMALLMONEY", HighlightColour.Datatype);
            highlightingStyles.Add("BIGINT", HighlightColour.Datatype);
            highlightingStyles.Add("VARBINARY", HighlightColour.Datatype);
            highlightingStyles.Add("VARCHAR", HighlightColour.Datatype);
            highlightingStyles.Add("BINARY", HighlightColour.Datatype);
            highlightingStyles.Add("CHAR", HighlightColour.Datatype);
            highlightingStyles.Add("TIMESTAMP", HighlightColour.Datatype);
            highlightingStyles.Add("NVARCHAR", HighlightColour.Datatype);
            highlightingStyles.Add("NCHAR", HighlightColour.Datatype);
            highlightingStyles.Add("SYSNAME", HighlightColour.Datatype);
            #endregion
        }
        #endregion

        #region Tokenising Helpers
        void getSQLFormattedString(string lineInput, SideObject sideObject)
        {
            // get a tokenised version of the input string
            StringTokenizer st = new StringTokenizer(lineInput);
            Token t;

            while ((t = st.Next()) != null)
            {
                if (sideObject.InCommentState)
                {
                    // ok we're in comment state - set the colour & output the current token
                    SetColour(HighlightColour.Comment, sideObject);
                    sideObject.Text.Append(t.Value);

                    // if this token isn't an end comment
                    if (t.Kind != TokenKind.EndComment)
                    {
                        // then keep reading...
                        while ((t = st.Next()) != null)
                        {
                            // ... output the current token ...
                            sideObject.Text.Append(t.Value);

                            // ... and if we're an end comment ...
                            if (t.Kind == TokenKind.EndComment)
                            {
                                // ... then cancel comment state and stop reading ...
                                sideObject.InCommentState = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // the first token on the line was an end comment - so we're no longer in the comment state
                        sideObject.InCommentState = false;
                    }
                }
                else
                {
                    if (sideObject.InSquareStringState)
                    {
                        // ok we're in square string state - check the token list and output the current token
                        CheckTokenListAndOutput(sideObject, t);
                        
                        // if this token isn't an end square
                        if (t.Kind != TokenKind.EndSquare)
                        {
                            // then keep reading...
                            while ((t = st.Next()) != null)
                            {
                                // ... check the token list and output the current token ...
                                CheckTokenListAndOutput(sideObject, t); 
                                
                                // ... and if we're an end square ...
                                if (t.Kind == TokenKind.EndSquare)
                                {
                                    // ... then cancel square string state and stop reading ...
                                    sideObject.InSquareStringState = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // the first token on the line was an end square - so we're no longer in the square string state
                            sideObject.InSquareStringState = false;
                        }
                    }
                    else
                    {
                        if (t.Kind == TokenKind.EOLComment)
                        {
                            // set comment highlight & output token
                            SetColour(HighlightColour.Comment, sideObject);
                            sideObject.Text.Append(t.Value);

                            // now read to the end of the line
                            while ((t = st.Next()) != null)
                            {
                                // and output each token (still in comment highlight)
                                sideObject.Text.Append(t.Value);
                            }
                        }
                        else if (t.Kind == TokenKind.StartComment)
                        {
                            // set comment highlight & output token
                            SetColour(HighlightColour.Comment, sideObject);
                            sideObject.Text.Append(t.Value);

                            // remember we're now in comment state
                            sideObject.InCommentState = true;
                        }
                        else if (t.Kind == TokenKind.StartSquare)
                        {
                            // set plain text highlight & output token
                            SetColour(HighlightColour.PlainText, sideObject);
                            sideObject.Text.Append(t.Value);

                            // remember we're now in square string state
                            sideObject.InSquareStringState = true;
                        }
                        else if (t.Kind == TokenKind.QuotedString)
                        {
                            // set string highlight & output token
                            SetColour(HighlightColour.String, sideObject);
                            sideObject.Text.Append(t.Value);
                        }
                        else if (t.Kind == TokenKind.Number)
                        {
                            // set number highlight & output token
                            SetColour(HighlightColour.Number, sideObject);
                            sideObject.Text.Append(t.Value);
                        }
                        else
                        {
                            // check keywords, functions etc & output token
                            CheckTokenListAndOutput(sideObject, t);
                        }
                    }
                }
            }
        }

        private static void SetColour(HighlightColour colour, SideObject sideObject)
        {
            // if the colour needs to be set
            if (sideObject.lastColourIndex != colour)
            {
                // then set the colour
                int i = (int)colour;
                sideObject.Text.Append("\\cf").Append(i.ToString()).Append(" ");

                // and record the fact
                sideObject.lastColourIndex = colour;
            }
        }

        private static void SetHighlight(HighlightColour colour, SideObject sideObject)
        {
            // if the highlight needs to be set
            if (sideObject.lastHighlightIndex != colour)
            {
                // then set the highlight
                int i = (int)colour;
                sideObject.Text.Append("\\highlight").Append(i.ToString()).Append(" ");

                // and record the fact
                sideObject.lastHighlightIndex = colour;
            }
        }

        private void CheckTokenListAndOutput(SideObject sideObject, Token token)
        {
            // ok so is this token on the keywords & functions list?
            object o = highlightingStyles[token.Value.ToUpperInvariant()];
            if (o != null)
            {
                // yes...
                if (sideObject.InSquareStringState && ((HighlightColour)o != HighlightColour.Datatype))
                {
                    // but we're in square string state and it's not a datatype... so plain text colour
                    SetColour(HighlightColour.PlainText, sideObject);
                }
                else
                {
                    // ok to set the colour to the one associated with the token
                    SetColour((HighlightColour)o, sideObject);
                }
            }
            else
            {
                // no - so plain text colour
                SetColour(HighlightColour.PlainText, sideObject);
            }

            // and append the token
            sideObject.Text.Append(token.Value);
        }


        private static void AppendLineBreak(SideObject left, SideObject right)
        {
            // append a line break to both the left & right
            left.Text.Append("\\par\n");
            right.Text.Append("\\par\n");
        }

        private static void AppendLineNumber(SideObject left, SideObject right, int cnt)
        {
            // set the highlight to white
            SetHighlight(HighlightColour.White, left);
            SetHighlight(HighlightColour.White, right);

            // set the line number colour
            SetColour(HighlightColour.LineNumber, left);
            SetColour(HighlightColour.LineNumber, right);

            // and append the line number text to the left & right
            left.Text.Append(cnt.ToString().PadLeft(4)).Append(" ");
            right.Text.Append(cnt.ToString().PadLeft(4)).Append(" ");
        }

        private static void AppendHeader(SideObject sideObject)
        {
            // append the standard header (including font setting & colour table) to side
            sideObject.Text.Append(@"{\rtf1\fbidis\ansi\ansicpg1255\deff0\deflang1037{\fonttbl{");
            sideObject.Text.Append(@"\f0\fnil\fcharset0Lucida Console;}");
            sideObject.Text.Append("}\n");
            sideObject.Text.Append(@"{\colortbl ;\red0\green0\blue0;\red255\green211\blue211;\red211\green255\blue211;\red211\green211\blue255;\red255\green255\blue255;\red0\green128\blue128;\red0\green0\blue255;\red255\green0\blue255;\red128\green128\blue128;\red0\green128\blue0;\red0\green0\blue128;\red255\green0\blue0;\red128\green0\blue0;");
            sideObject.Text.Append("}\n");
            sideObject.Text.Append(@"\viewkind4\uc1\pard\ltrpar\fs16 ");
        }
        #endregion

        #region Main Comparison Function
        public void CompareText()
        {
            // load the source and destination as TextFile objects
            DiffList_TextFile tfSource = new DiffList_TextFile(leftText_);
            DiffList_TextFile tfDestination = new DiffList_TextFile(rightText_);

            // use DiffEngine to generate the difference list
            DiffEngine de = new DiffEngine();
            de.ProcessDiff(tfSource, tfDestination, DiffEngineLevel.SlowPerfect);
            ArrayList DiffLines = de.DiffReport();

            // create the objects to track the left & right sides
            SideObject leftState = new SideObject();
            SideObject rightState = new SideObject();

            // add the RTF header to the left & right side objects
            AppendHeader(leftState);
            AppendHeader(rightState);

            // initialise our variables
            int cnt = 1;
            int i = 0;

            // now go through the result spans
            foreach (DiffResultSpan drs in DiffLines)
            {
                // what is this Diff's status?
                switch (drs.Status)
                {
                    // a source line was deleted
                    case DiffResultSpanStatus.DeleteSource:
                    {
                        // for each line in the diff
                        for (i = 0; i < drs.Length; i++)
                        {
                            // put the line number on the left & right
                            AppendLineNumber(leftState, rightState, cnt);

                            // set highlight and output line on the left only
                            SetHighlight(HighlightColour.DeletedLine, leftState);
                            getSQLFormattedString(((TextLine)tfSource.GetByIndex(drs.SourceIndex + i)).Line, leftState);

                            // put in the line break
                            AppendLineBreak(leftState, rightState);

                            // increase the line count
                            cnt++;
                        }
                    } break;

                    // there was no change
                    case DiffResultSpanStatus.NoChange:
                    {
                        for (i = 0; i < drs.Length; i++)
                        {
                            // put the line number on the left & right
                            AppendLineNumber(leftState, rightState, cnt);

                            // output line on the left & right
                            getSQLFormattedString(((TextLine)tfSource.GetByIndex(drs.SourceIndex + i)).Line, leftState);
                            getSQLFormattedString(((TextLine)tfDestination.GetByIndex(drs.DestIndex + i)).Line, rightState);

                            // put in the line break
                            AppendLineBreak(leftState, rightState);

                            // increase the line count
                            cnt++;
                        }
                    } break;

                    // a target line was added
                    case DiffResultSpanStatus.AddDestination:
                    {
                        for (i = 0; i < drs.Length; i++)
                        {
                            // put the line number on the left & right
                            AppendLineNumber(leftState, rightState, cnt);

                            // set highlight and output line on the right only
                            SetHighlight(HighlightColour.AddedLine, rightState);
                            getSQLFormattedString(((TextLine)tfDestination.GetByIndex(drs.DestIndex + i)).Line, rightState);

                            // put in the line break
                            AppendLineBreak(leftState, rightState);

                            // increase the line count
                            cnt++;
                        }
                    } break;

                    // the text of the line changed
                    case DiffResultSpanStatus.Replace:
                    {
                        for (i = 0; i < drs.Length; i++)
                        {
                            // put the line number on the left & right
                            AppendLineNumber(leftState, rightState, cnt);

                            // set highlight & output line on the left & right
                            SetHighlight(HighlightColour.ChangedLine, leftState);
                            SetHighlight(HighlightColour.ChangedLine, rightState);
                            getSQLFormattedString(((TextLine)tfSource.GetByIndex(drs.SourceIndex + i)).Line, leftState);
                            getSQLFormattedString(((TextLine)tfDestination.GetByIndex(drs.DestIndex + i)).Line, rightState);

                            // put in the line break
                            AppendLineBreak(leftState, rightState);

                            // increase the line count
                            cnt++;
                        }
                    } break;
                }
            }

            // now set the built text into the left & right rich text boxes
            rtbLeft.Rtf = leftState.Text.ToString();
            rtbRight.Rtf = rightState.Text.ToString();
        }
        #endregion
    }

    enum HighlightColour
    {
        Unknown = 0,
        PlainText,
        DeletedLine,
        AddedLine,
        ChangedLine,
        White,
        LineNumber,
        Keyword,
        Function,
        Operator,
        Comment,
        Datatype,
        String,
        Number
    }

    class SideObject
    {
        public StringBuilder Text = new StringBuilder(1024);
        public bool InSquareStringState = false;
        public bool InCommentState = false;
        public HighlightColour lastColourIndex = HighlightColour.Unknown;
        public HighlightColour lastHighlightIndex = HighlightColour.Unknown;        
    }
}
