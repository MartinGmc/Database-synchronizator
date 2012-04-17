using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class DbSyncColumnDiff
    {
        private Columnn ColumnA;
        private Columnn ColumnB;

        private string columnName;

        private bool different = false;
        private bool diffNameOfColumn = false;
        private bool diffIsPrimarykey = false;
        private bool diffNameOfPk = false;
        private bool diffIsForeinKey = false;
        private bool diffNameOfFK = false;
        private bool diffFkNameOfPKTab = false;
        private bool diffFkNameOfPkCol = false;
        //private bool diffTableName = false;
        private bool diffColumnName = false;
        //private bool diffOrdinalPosition = false;
        private bool diffColumnDefault = false;
        private bool diffIsNullable = false;
        private bool diffDatatype = false;
        private bool diffCharMaxLength = false;
        private bool diffCharOctetLength = false;
        private bool diffNumericPrecision = false;
        //private bool diffNumericPRecisionRadix = false;
        private bool diffNumericScale = false;
        private bool diffDatetimePrecision = false;
        private bool diffCharacterSetCatalog = false;
        private bool diffCharacterSetSchema = false;
        private bool diffCharacterSetName = false;

        private List<ObjectAtribute> columnAtributesListA;
        private List<ObjectAtribute> columnAtributesListB;

       

        internal List<ObjectAtribute> ColumnAtributesListB
        {
            get { return columnAtributesListB; }
           
        }

        internal List<ObjectAtribute> ColumnAtributesListA
        {
            get { return columnAtributesListA; }

        }
        
        public Columnn getColumnA()
        {
            return ColumnA;
        }

        public Columnn getColumnB()
        {
            return ColumnB;
        }
        
        public DbSyncColumnDiff(Columnn columnAin, Columnn columnBin)
        {
            ColumnA = columnAin;
            ColumnB = columnBin;


            columnAtributesListA = new List<ObjectAtribute>();
            columnAtributesListB = new List<ObjectAtribute>();

            if (ColumnA == null || ColumnB == null)
            {
                if (ColumnA != null)
                {
                    this.columnName = ColumnA.COULUMN_NAME1;
                    columnAtributesListA.Add(new ObjectAtribute("Name of column", ColumnA.COULUMN_NAME1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Coulumn default", ColumnA.COULUMN_DEFAULT1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Datatype", ColumnA.DATA_TYPE1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Date Time Precision", ColumnA.DATETIME_PRECISION1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Character set catalog", ColumnA.CHARACTER_SET_CATALOG1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Character set name", ColumnA.CHARACTER_SET_NAME1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Character set schema", ColumnA.CHARACTER_SET_SCHEMA1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Character max length", ColumnA.CHARACTER_MAXIMUM_LENGTH1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Character octet length", ColumnA.CHARACTER_OCTET_LENGTH1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Is nullable", ColumnA.IS_NULLABLE1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Numeric precision", ColumnA.NUMERIC_PRECISION1, true));
                    columnAtributesListA.Add(new ObjectAtribute("Numeric scale", ColumnA.NUMERIC_SCALE1, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Name of fk Column", ColumnA.FK_NameOFPKCol, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Name of fk Tab", ColumnA.FK_nameOFPKTab, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Is forein Key", ColumnA.Is_foreinKey().ToString(), true));
                    //columnAtributesListA.Add(new ObjectAtribute("Is primary Key", ColumnA.Is_primaryKey().ToString(), true));
                    //columnAtributesListA.Add(new ObjectAtribute("Name of Fk", ColumnA.Name_of_FK, true));
                    //columnAtributesListA.Add(new ObjectAtribute("Name of pk", ColumnA.Name_of_PK, true));
                }
                else if (ColumnB != null)
                {
                    this.columnName = ColumnB.COULUMN_NAME1;
                    columnAtributesListB.Add(new ObjectAtribute("Name of column", ColumnB.COULUMN_NAME1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Coulumn default", ColumnB.COULUMN_DEFAULT1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Datatype", ColumnB.DATA_TYPE1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Date Time Precision", ColumnB.DATETIME_PRECISION1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Character set catalog", ColumnB.CHARACTER_SET_CATALOG1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Character set name", ColumnB.CHARACTER_SET_NAME1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Character set schema", ColumnB.CHARACTER_SET_SCHEMA1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Character max length", ColumnB.CHARACTER_MAXIMUM_LENGTH1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Character octet length", ColumnB.CHARACTER_OCTET_LENGTH1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Is nullable", ColumnB.IS_NULLABLE1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Numeric precision", ColumnB.NUMERIC_PRECISION1, true));
                    columnAtributesListB.Add(new ObjectAtribute("Numeric scale", ColumnB.NUMERIC_SCALE1, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Name of fk Column", ColumnB.FK_NameOFPKCol, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Name of fk Tab", ColumnB.FK_nameOFPKTab, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Is forein Key", ColumnB.Is_foreinKey().ToString(), true));
                    //columnAtributesListB.Add(new ObjectAtribute("Is primary Key", ColumnB.Is_primaryKey().ToString(), true));
                    //columnAtributesListB.Add(new ObjectAtribute("Name of Fk", ColumnB.Name_of_FK, true));
                    //columnAtributesListB.Add(new ObjectAtribute("Name of pk", ColumnB.Name_of_PK, true));
                }
                else this.columnName = "UNDEFINED";
            }
            if (ColumnA != null && ColumnB != null)
            {
                this.columnName = ColumnA.COULUMN_NAME1;
                if (ColumnA.COULUMN_DEFAULT1 != ColumnB.COULUMN_DEFAULT1) diffColumnDefault = true;
                if (ColumnA.COULUMN_NAME1 != ColumnB.COULUMN_NAME1) diffColumnName = true;
                if (ColumnA.DATA_TYPE1 != ColumnB.DATA_TYPE1) diffDatatype = true;
                if (ColumnA.DATETIME_PRECISION1 != ColumnB.DATETIME_PRECISION1) diffDatetimePrecision = true;
                //if (ColumnA.FK_NameOFPKCol != ColumnB.FK_NameOFPKCol) diffFkNameOfPkCol = true;
                //if (ColumnA.FK_nameOFPKTab != ColumnB.FK_nameOFPKTab) diffFkNameOfPKTab = true;
                if (ColumnA.CHARACTER_MAXIMUM_LENGTH1 != ColumnB.CHARACTER_MAXIMUM_LENGTH1) diffCharMaxLength = true;
                //if (ColumnA.CHARACTER_OCTET_LENGTH1 != ColumnB.CHARACTER_OCTET_LENGTH1) diffCharOctetLength = true;
                //if (ColumnA.CHARACTER_SET_CATALOG1 != ColumnB.CHARACTER_SET_CATALOG1) diffCharacterSetCatalog = true;
                //if (ColumnA.CHARACTER_SET_NAME1 != ColumnB.CHARACTER_SET_NAME1) diffCharacterSetName = true;
                //if (ColumnA.CHARACTER_SET_SCHEMA1 != ColumnB.CHARACTER_SET_SCHEMA1) diffCharacterSetSchema = true;
                if (ColumnA.IS_NULLABLE1 != ColumnB.IS_NULLABLE1) diffIsNullable = true;
                //if (ColumnA.Name_of_FK != ColumnB.Name_of_FK) diffNameOfFK = true;
                //if (ColumnA.Name_of_PK != ColumnB.Name_of_PK) diffNameOfPk = true;
                //if (ColumnA.NazovStlpca != ColumnB.NazovStlpca) diffNameOfColumn = true;
                //if (ColumnA.NUMERIC_PRECISION_RADIX1 != ColumnB.NUMERIC_PRECISION_RADIX1) diffNumericPRecisionRadix = true;
                if (ColumnA.NUMERIC_PRECISION1 != ColumnB.NUMERIC_PRECISION1) diffNumericPrecision = true;
                if (ColumnA.NUMERIC_SCALE1 != ColumnB.NUMERIC_SCALE1) diffNumericScale = true;
               // if (ColumnA.ORDINAL_POSITION1 != ColumnB.ORDINAL_POSITION1) diffOrdinalPosition = true;
                //if (ColumnA.TABLE_NAME1 != ColumnB.TABLE_NAME1) diffTableName = true;
                //if (ColumnA.Is_foreinKey() != ColumnB.Is_foreinKey()) diffIsForeinKey = true;
                //if (ColumnA.Is_primaryKey() != ColumnB.Is_primaryKey()) diffIsPrimarykey = true;

                if (diffColumnDefault || diffColumnName || diffDatatype || diffDatetimePrecision || diffFkNameOfPkCol || diffFkNameOfPKTab || diffCharacterSetCatalog || diffCharacterSetName || diffCharacterSetSchema || diffCharMaxLength || diffCharOctetLength || diffIsForeinKey || diffIsNullable || diffIsPrimarykey || diffNameOfColumn || diffNameOfFK || diffNameOfPk || diffNumericPrecision || diffNumericScale ) different = true;
                else different = false;
            
                //naplnenie zoznamu atributov pre potreby zobrazovania


                ObjectAtribute columnNameOA = new ObjectAtribute("Name of column", columnName, false);
                columnAtributesListA.Add(columnNameOA);
                columnAtributesListB.Add(columnNameOA);

                if (diffColumnDefault)
                {
                    ObjectAtribute cDefaultA = new ObjectAtribute("Coulumn default ", ColumnA.COULUMN_DEFAULT1, true);
                    columnAtributesListA.Add(cDefaultA);
                    ObjectAtribute cDefaultB = new ObjectAtribute("Coulumn default ", ColumnB.COULUMN_DEFAULT1, true);
                    columnAtributesListB.Add(cDefaultB);
                }
                else
                {
                    ObjectAtribute cDefault = new ObjectAtribute("Coulumn default ", ColumnA.COULUMN_DEFAULT1, false);
                    columnAtributesListA.Add(cDefault);
                    columnAtributesListB.Add(cDefault);
                }

                if (diffDatatype)
                {
                    ObjectAtribute cDatatypeA = new ObjectAtribute("Datatype ", ColumnA.DATA_TYPE1, true);
                    columnAtributesListA.Add(cDatatypeA);
                    ObjectAtribute cDatatypeB = new ObjectAtribute("Datatype ", ColumnB.DATA_TYPE1, true);
                    columnAtributesListB.Add(cDatatypeB);
                }
                else
                {
                    ObjectAtribute cDatatype = new ObjectAtribute("Datatype ", ColumnA.DATA_TYPE1, false);
                    columnAtributesListA.Add(cDatatype);
                    columnAtributesListB.Add(cDatatype);
                }

                if (diffDatetimePrecision)
                {
                    ObjectAtribute cDateTimePrecisionA = new ObjectAtribute("Date Time Precision ", ColumnA.DATETIME_PRECISION1, true);
                    columnAtributesListA.Add(cDateTimePrecisionA);
                    ObjectAtribute cDateTimePrecisionB = new ObjectAtribute("Date Time Precision ", ColumnB.DATETIME_PRECISION1, true);
                    columnAtributesListB.Add(cDateTimePrecisionB);
                }
                else
                {
                    ObjectAtribute cDateTimePrecision = new ObjectAtribute("Date Time Precision ", ColumnA.DATETIME_PRECISION1, false);
                    columnAtributesListA.Add(cDateTimePrecision);
                    columnAtributesListB.Add(cDateTimePrecision);
                }

                //if (diffCharacterSetCatalog)
                //{
                //    ObjectAtribute cCheracterSetCatA = new ObjectAtribute("Character set catalog ", ColumnA.CHARACTER_SET_CATALOG1, true);
                //    columnAtributesListA.Add(cCheracterSetCatA);
                //    ObjectAtribute cCheracterSetCatB = new ObjectAtribute("Character set catalog ", ColumnB.CHARACTER_SET_CATALOG1, true);
                //    columnAtributesListB.Add(cCheracterSetCatB);
                //}
                //else
                //{
                //    ObjectAtribute cCheracterSetCat = new ObjectAtribute("Character set catalog ", ColumnA.CHARACTER_SET_CATALOG1, false);
                //    columnAtributesListA.Add(cCheracterSetCat);
                //    columnAtributesListB.Add(cCheracterSetCat);
                //}

                //if (diffCharacterSetName)
                //{
                //    ObjectAtribute cCharacterSetNameA = new ObjectAtribute("Character set name ", ColumnA.CHARACTER_SET_NAME1, true);
                //    columnAtributesListA.Add(cCharacterSetNameA);
                //    ObjectAtribute cCharacterSetNameB = new ObjectAtribute("Character set name", ColumnB.CHARACTER_SET_NAME1, true);
                //    columnAtributesListB.Add(cCharacterSetNameB);
                //}
                //else
                //{
                //    ObjectAtribute cCheracterSetCat = new ObjectAtribute("Character set name ", ColumnA.CHARACTER_SET_NAME1, false);
                //    columnAtributesListA.Add(cCheracterSetCat);
                //    columnAtributesListB.Add(cCheracterSetCat);
                //}

                //if (diffCharacterSetSchema)
                //{
                //    ObjectAtribute cCharacterSetSchemaA = new ObjectAtribute("Character set schema ", ColumnA.CHARACTER_SET_SCHEMA1, true);
                //    columnAtributesListA.Add(cCharacterSetSchemaA);
                //    ObjectAtribute cCharacterSetSchemaB = new ObjectAtribute("Character set schema", ColumnB.CHARACTER_SET_SCHEMA1, true);
                //    columnAtributesListB.Add(cCharacterSetSchemaB);
                //}
                //else
                //{
                //    ObjectAtribute cCharacterSetSchema = new ObjectAtribute("Character set schema", ColumnA.CHARACTER_SET_SCHEMA1, false);
                //    columnAtributesListA.Add(cCharacterSetSchema);
                //    columnAtributesListB.Add(cCharacterSetSchema);
                //}

                if (diffCharMaxLength)
                {
                    ObjectAtribute cCharacterMaxLEngthA = new ObjectAtribute("Character max length ", ColumnA.CHARACTER_MAXIMUM_LENGTH1, true);
                    columnAtributesListA.Add(cCharacterMaxLEngthA);
                    ObjectAtribute cCharacterMaxLEngthB = new ObjectAtribute("Character max length ", ColumnB.CHARACTER_MAXIMUM_LENGTH1, true);
                    columnAtributesListB.Add(cCharacterMaxLEngthB);
                }
                else
                {
                    ObjectAtribute cCharacterMaxLEngth = new ObjectAtribute("Character max length ", ColumnA.CHARACTER_MAXIMUM_LENGTH1, false);
                    columnAtributesListA.Add(cCharacterMaxLEngth);
                    columnAtributesListB.Add(cCharacterMaxLEngth);
                }

                // if (diffCharOctetLength)
                //{
                //    ObjectAtribute cCharacterOctetLEngthA = new ObjectAtribute("Character octet length ", ColumnA.CHARACTER_OCTET_LENGTH1, true);
                //    columnAtributesListA.Add(cCharacterOctetLEngthA);
                //    ObjectAtribute cCharacterOctetLEngthB = new ObjectAtribute("Character octet length ", ColumnB.CHARACTER_OCTET_LENGTH1, true);
                //    columnAtributesListB.Add(cCharacterOctetLEngthB);
                //}
                //else
                //{
                //    ObjectAtribute cCharacterOctetLEngth = new ObjectAtribute("Character octet length ", ColumnA.CHARACTER_OCTET_LENGTH1, false);
                //    columnAtributesListA.Add(cCharacterOctetLEngth);
                //    columnAtributesListB.Add(cCharacterOctetLEngth);
                //}

                if (diffIsNullable)
                {
                    ObjectAtribute cIsNullableA = new ObjectAtribute("Is nullable ", ColumnA.IS_NULLABLE1, true);
                    columnAtributesListA.Add(cIsNullableA);
                    ObjectAtribute cIsNullableB = new ObjectAtribute("Is nullable ", ColumnB.IS_NULLABLE1, true);
                    columnAtributesListB.Add(cIsNullableB);
                }
                else
                {
                    ObjectAtribute cIsNullable = new ObjectAtribute("Is nullable", ColumnA.IS_NULLABLE1, false);
                    columnAtributesListA.Add(cIsNullable);
                    columnAtributesListB.Add(cIsNullable);
                }

                if (diffNumericPrecision)
                {
                    ObjectAtribute cNumericPrecisionA = new ObjectAtribute("Numeric precision ", ColumnA.NUMERIC_PRECISION1, true);
                    columnAtributesListA.Add(cNumericPrecisionA);
                    ObjectAtribute cNumericPrecisionB = new ObjectAtribute("Numeric precision ", ColumnB.NUMERIC_PRECISION1, true);
                    columnAtributesListB.Add(cNumericPrecisionB);
                }
                else
                {
                    ObjectAtribute cNumericPrecision = new ObjectAtribute("Numeric precision ", ColumnA.NUMERIC_PRECISION1, false);
                    columnAtributesListA.Add(cNumericPrecision);
                    columnAtributesListB.Add(cNumericPrecision);
                }

               

                if (diffNumericScale)
                {
                    ObjectAtribute cNumericScaleA = new ObjectAtribute("Numeric scale ", ColumnA.NUMERIC_SCALE1, true);
                    columnAtributesListA.Add(cNumericScaleA);
                    ObjectAtribute cNumericScaleB = new ObjectAtribute("Numeric scale", ColumnB.NUMERIC_SCALE1, true);
                    columnAtributesListB.Add(cNumericScaleB);
                }
                else
                {
                    ObjectAtribute cNumericScale = new ObjectAtribute("Numeric scale", ColumnA.NUMERIC_SCALE1, false);
                    columnAtributesListA.Add(cNumericScale);
                    columnAtributesListB.Add(cNumericScale);
                }

               

                //if (diffFkNameOfPkCol)
                //{
                //    ObjectAtribute cNameOfPkColA = new ObjectAtribute("Name of fk Column ", ColumnA.FK_NameOFPKCol, true);
                //    columnAtributesListA.Add(cNameOfPkColA);
                //    ObjectAtribute cNameOfPkColB = new ObjectAtribute("Name of fk Column ", ColumnB.FK_NameOFPKCol, true);
                //    columnAtributesListB.Add(cNameOfPkColB);
                //}
                //else
                //{
                //    ObjectAtribute cNameOfPkCol = new ObjectAtribute("Name of fk Column ", ColumnA.FK_NameOFPKCol, false);
                //    columnAtributesListA.Add(cNameOfPkCol);
                //    columnAtributesListB.Add(cNameOfPkCol);
                //}

                //if (diffFkNameOfPKTab)
                //{
                //    ObjectAtribute cNameOfPkTabA = new ObjectAtribute("Name of fk Tab ", ColumnA.FK_nameOFPKTab, true);
                //    columnAtributesListA.Add(cNameOfPkTabA);
                //    ObjectAtribute cNameOfPkTabB = new ObjectAtribute("Name of fk Tab ", ColumnB.FK_nameOFPKTab, true);
                //    columnAtributesListB.Add(cNameOfPkTabB);
                //}
                //else
                //{
                //    ObjectAtribute cNameOfPkTab = new ObjectAtribute("Name of fk Tab ", ColumnA.FK_nameOFPKTab, false);
                //    columnAtributesListA.Add(cNameOfPkTab);
                //    columnAtributesListB.Add(cNameOfPkTab);
                //}

                //if (diffIsForeinKey)
                //{
                //    ObjectAtribute cIsForeinKeyA = new ObjectAtribute("Is forein Key ", ColumnA.Is_foreinKey().ToString(), true);
                //    columnAtributesListA.Add(cIsForeinKeyA);
                //    ObjectAtribute cIsForeinKeyB = new ObjectAtribute("Is forein Key ", ColumnB.Is_foreinKey().ToString(), true);
                //    columnAtributesListB.Add(cIsForeinKeyB);
                //}
                //else
                //{
                //    ObjectAtribute cIsForeinKey = new ObjectAtribute("Is forein Key ", ColumnA.Is_foreinKey().ToString(), false);
                //    columnAtributesListA.Add(cIsForeinKey);
                //    columnAtributesListB.Add(cIsForeinKey);
                //}

                //if (diffIsPrimarykey)
                //{
                //    ObjectAtribute cIsPrimaryKeyA = new ObjectAtribute("Is primary Key ", ColumnA.Is_primaryKey().ToString(), true);
                //    columnAtributesListA.Add(cIsPrimaryKeyA);
                //    ObjectAtribute cIsPrimaryKeyB = new ObjectAtribute("Is primary Key ", ColumnB.Is_primaryKey().ToString(), true);
                //    columnAtributesListB.Add(cIsPrimaryKeyB);
                //}
                //else
                //{
                //    ObjectAtribute cIsPrimaryKey = new ObjectAtribute("Is primary Key ", ColumnA.Is_primaryKey().ToString(), false);
                //    columnAtributesListA.Add(cIsPrimaryKey);
                //    columnAtributesListB.Add(cIsPrimaryKey);
                //}
                
                //if (diffNameOfFK)
                //{
                //    ObjectAtribute cNameOfFkA = new ObjectAtribute("Name of Fk ", ColumnA.Name_of_FK, true);
                //    columnAtributesListA.Add(cNameOfFkA);
                //    ObjectAtribute cNameOfFkB = new ObjectAtribute("Name of Fk ", ColumnB.Name_of_FK, true);
                //    columnAtributesListB.Add(cNameOfFkB);
                //}
                //else
                //{
                //    ObjectAtribute cNameOfFk = new ObjectAtribute("Name of Fk ", ColumnA.Name_of_FK, false);
                //    columnAtributesListA.Add(cNameOfFk);
                //    columnAtributesListB.Add(cNameOfFk);
                //}

                //if (diffNameOfPk)
                //{
                //    ObjectAtribute cNameOfPkA = new ObjectAtribute("Name of pk ", ColumnA.Name_of_PK, true);
                //    columnAtributesListA.Add(cNameOfPkA);
                //    ObjectAtribute cNameOfPkB = new ObjectAtribute("Name of pk ", ColumnB.Name_of_PK, true);
                //    columnAtributesListB.Add(cNameOfPkB);
                //}
                //else
                //{
                //    ObjectAtribute cNameOfPk = new ObjectAtribute("Name of pk ", ColumnA.Name_of_PK, false);
                //    columnAtributesListA.Add(cNameOfPk);
                //    columnAtributesListB.Add(cNameOfPk);
                //}



            }
            else different = true;



        }
        public string getName()
        {
            return this.columnName;
        }

        public bool isDifferent()
        {
            return different;
        }

        public override string ToString()
        {
            return this.columnName + " " + this.different.ToString();
        }

    }
}
