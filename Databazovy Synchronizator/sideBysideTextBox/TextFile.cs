using System;
using System.IO;
using System.Collections;

namespace Databazovy_Synchronizator
{
	public class TextLine : IComparable
	{
		public string Line;
		public int _hash;

		public TextLine(string str)
		{
			Line = str.Replace("\t","    ");
			_hash = str.GetHashCode();
		}
		#region IComparable Members

		public int CompareTo(object obj)
		{
			return _hash.CompareTo(((TextLine)obj)._hash);
		}

		#endregion
	}


	public class DiffList_TextFile : IDiffList
	{
		private const int MaxLineLength = 1024;
		private ArrayList _lines;

		public DiffList_TextFile(string Text)
		{
			_lines = new ArrayList();

            string[] linesArray = Text.Split(new char[] { '\n' });
            foreach (string s in linesArray)
            {
                _lines.Add(new TextLine(s));
            }
		}
		#region IDiffList Members

		public int Count()
		{
			return _lines.Count;
		}

		public IComparable GetByIndex(int index)
		{
			return (TextLine)_lines[index];
		}

		#endregion
	
	}
}