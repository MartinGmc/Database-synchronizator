using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
   public class Columnn :IDbsyncCompare<Columnn>
    {
        //private string nazovStlpca;
        private bool diffNazovStlpca = false;

       

     
        //private string TABLE_SCHEMA;                // potencialne pouzitelny stlpec
        //private string TABLE_NAME;                  // potencialne pouzitelny stlpec
        //private bool diffTableName = false;
        private string COULUMN_NAME;                // potencialne pouzitelny stlpec  
        //private bool diffColumn_name = false;
        //private string ORDINAL_POSITION;            // potencialne pouzitelny stlpec  
        //private bool diffOrdinal_position = false;
        private string COULUMN_DEFAULT;             // potencialne pouzitelny stlpec  
        //private bool diffColumn_Default = false;
        private string IS_NULLABLE;                 // potencialne pouzitelny stlpec
       // private bool diffIs_nullable = false;
        private string DATA_TYPE;                   // potencialne pouzitelny stlpec
        //private bool diffDataType = false;
        private string CHARACTER_MAXIMUM_LENGTH;    // potencialne pouzitelny stlpec
        //private bool diffCharacterMAximumLength = false;
        //private string CHARACTER_OCTET_LENGTH;
        //private bool diffCharacterOctetLength = false;
        private string NUMERIC_PRECISION;           // potencialne pouzitelny stlpec
        //private bool diffNumericPrecision = false;
        //private string NUMERIC_PRECISION_RADIX;
        //private bool diffNumericPrecisionRadix = false;
        private string NUMERIC_SCALE;               // potencialne pouzitelny stlpec
        
        private string DATETIME_PRECISION;          // potencialne pouzitelny stlpec
        //private string CHARACTER_SET_CATALOG;       // potencialne pouzitelny stlpec???
        //private string CHARACTER_SET_SCHEMA;        // potencialne pouzitelny stlpec???
        //private string CHARACTER_SET_NAME;          // potencialne pouzitelny stlpec???
        //private string COLLATION_CATALOG;           
        //private string COLLATION_SCHEMA;
        //private string COLLATION_NAME;
        //private string DOMAIN_CATALOG;
        //private string DOMAIN_SCHEMA;
        //private string DOMAIN_NAME;
        
       //gety a sety

       
        
      
        
       

        
        
       
       
        public string COULUMN_NAME1
        {
            get { return COULUMN_NAME; }
            set { COULUMN_NAME = value; }
        }
      
        public string COULUMN_DEFAULT1
        {
            get { return COULUMN_DEFAULT; }
            set { COULUMN_DEFAULT = value; }
        }
        public string IS_NULLABLE1
        {
            get { return IS_NULLABLE; }
            set { IS_NULLABLE = value; }
        }
        public string DATA_TYPE1
        {
            get { return DATA_TYPE; }
            set { DATA_TYPE = value; }
        }
        public string CHARACTER_MAXIMUM_LENGTH1
        {
            get { return CHARACTER_MAXIMUM_LENGTH; }
            set { CHARACTER_MAXIMUM_LENGTH = value; }
        }
        
       
        public string NUMERIC_PRECISION1
        {
            get { return NUMERIC_PRECISION; }
            set { NUMERIC_PRECISION = value; }
        }
        
        public string NUMERIC_SCALE1
        {
            get { return NUMERIC_SCALE; }
            set { NUMERIC_SCALE = value; }
        }
        public string DATETIME_PRECISION1
        {
            get { return DATETIME_PRECISION; }
            set { DATETIME_PRECISION = value; }
        }
        
       
      
       
        
       
     
       

       

        public override string ToString()
        {
            string vysledok = "";
            vysledok += "Coulumn name :" + this.COULUMN_NAME + "         \r\n\r\n";

           
            vysledok += "Coulumn default :" + this.COULUMN_DEFAULT + "\r\n";
           
            vysledok += "Datetime precision :" + this.DATETIME_PRECISION + "\r\n";
            
            vysledok += "character maximum length :" + this.CHARACTER_MAXIMUM_LENGTH + "\r\n";
            //vysledok += "character octet length :" + this.CHARACTER_OCTET_LENGTH + "\r\n";
            //vysledok += "character set catalog :" + this.CHARACTER_SET_CATALOG + "\r\n";
            //vysledok += "character set name :" + this.CHARACTER_SET_NAME + "\r\n";
            //vysledok += "character set schema :" + this.CHARACTER_SET_SCHEMA + "\r\n";
            vysledok += "Is nullable :" + this.IS_NULLABLE + "\r\n";
            vysledok += "Numeric precision :" + this.NUMERIC_PRECISION + "\r\n";
            //vysledok += "Numeric precision radx :" + this.NUMERIC_PRECISION_RADIX + "\r\n";
            vysledok += "Numeric scale :" + this.NUMERIC_SCALE + "\r\n";
            //vysledok += "Ordinal position :" + this.ORDINAL_POSITION + "\r\n";
           
           // vysledok += "Table name :" + this.TABLE_NAME + "\r\n";
           
            //if (is_PrimaryKey) vysledok += "primarny kluc s nazvom :" + this.name_of_PK +"\r\n";
            //if (is_ForeinKey)
           // {
           //     vysledok += "cudzi kluc s nazvom : " + this.name_of_FK + "\r\n";
           //     vysledok += "v cudzej tabulke    : " + this.fK_nameOFPKTab + "\r\n";
           //     vysledok += "stlpec              : " + this.fK_NameOFPKCol + "\r\n";
            //}


            return vysledok;
        }

        public bool DBSyncCompareTO(Columnn s)
        {
            bool ress = true;
            if (this.COULUMN_NAME1 != s.COULUMN_NAME1) ress = false;
            if (this.COULUMN_DEFAULT1 != s.COULUMN_DEFAULT1) ress = false;
            if (this.DATA_TYPE1 != s.DATA_TYPE1) ress = false;
            if (this.DATETIME_PRECISION1 != s.DATETIME_PRECISION1) ress = false;
            //if (this.FK_NameOFPKCol != s.FK_NameOFPKCol) ress = false;
            //if (this.FK_nameOFPKTab != s.FK_nameOFPKTab) ress = false;
            if (this.CHARACTER_MAXIMUM_LENGTH1 != s.CHARACTER_MAXIMUM_LENGTH1) ress = false;
            //if (this.CHARACTER_OCTET_LENGTH1 != s.CHARACTER_OCTET_LENGTH1) ress = false;
            //if (this.CHARACTER_SET_CATALOG1 != s.CHARACTER_SET_CATALOG1) ress = false;
            //if (this.CHARACTER_SET_NAME1 != s.CHARACTER_SET_NAME1) ress = false;
            //if (this.CHARACTER_SET_SCHEMA1 != s.CHARACTER_SET_SCHEMA1) ress = false;
            //if (this.Is_foreinKey() != s.Is_foreinKey()) ress = false;
            if (this.IS_NULLABLE1 != s.IS_NULLABLE1) ress = false;
            //if (this.Is_primaryKey() != s.Is_primaryKey()) ress = false;
            //if (this.Name_of_FK != s.Name_of_FK) ress = false;
            //if (this.Name_of_PK != s.Name_of_PK) ress = false;
            //if (this.NazovStlpca != s.NazovStlpca) ress = false;
            //if (this.NUMERIC_PRECISION_RADIX1 != s.NUMERIC_PRECISION_RADIX1) ress = false;
            if (this.NUMERIC_PRECISION1 != s.NUMERIC_PRECISION1) ress = false;
            if (this.NUMERIC_SCALE1 != s.NUMERIC_SCALE1) ress = false;
           // if (this.ORDINAL_POSITION1 != s.ORDINAL_POSITION1) ress = false;
            //if (this.TABLE_CATALOG1 != s.TABLE_CATALOG1) ress = false;
            //if (this.TABLE_NAME1 != s.TABLE_NAME1) ress = false;
        
            return ress;
            }
       
       
       public string getName()
        {
            return this.COULUMN_NAME1;
        }
    }
}
