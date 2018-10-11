using System;
using System.Text;
using System.IO;
using System.Data;

namespace TecanProgrammingTask_Mokrani
{
    class CsvProcessing
    {
        private string inputFileCsv;

        public CsvProcessing(string InputFilePath)
        {
            inputFileCsv = InputFilePath;
            
        }


        DataTable mydata ;
        //Convert the csv Contents into a datatable
        public void readCsv()
        {
            mydata = new DataTable();  //create an empty DataTable
            StreamReader sr = new StreamReader(inputFileCsv); 
            string[] arr;                        //array in which you will store the elemnets of each line
            bool mydatasetup = false;            //a variable to check in the loop if its already added the necessary number of columns to the datatable 

            using (sr)
            {
                int i = 0;
                while (sr.EndOfStream == false)    //read the whole file
                {
                    
                    string line = sr.ReadLine();    //get a line from the file

                    if (line != null && line != String.Empty) //check if there is content in the line
                    {
                        arr = line.Split(';');    //split the line at each ";" and put the elements in the array

                        if (mydatasetup == false)   //after reading the first line add as many columns you need to the datatable 
                        {
                            for (int u = 0; u < arr.Length; u++)
                            {
                                mydata.Columns.Add();
                            }
                            mydatasetup = true; //do this only once (to escape from an unneccessary big datatable)
                        }

                        mydata.Rows.Add();   //add a row in the datatable in which you will store the data of the line

                        for (int j = 0; j < arr.Length; j++)    //go throught each element in the array and put it into Datatable
                        {
                            if (arr[j] != "")
                            {
                                mydata.Rows[i][j] = arr[j];
                            }
                        }
                        i = i + 1; //increase the counter so that the program knows it has to fill the data from the next line into the next row of the datatable
                    }
                }
               
            }
                    
        }
        

        //transpose the dataTable contents
        public StringBuilder transposeCsv()
        {
            StringBuilder sb = new StringBuilder();  //create a stringbuilder

            for (int u = 0; u < mydata.Columns.Count; u++)   //loop through the COLUMNS of your datatable
            {
                for (int i = 0; i < mydata.Rows.Count; i++)  //for each column go through each row in the datatable first  
                {
                    sb.Append(mydata.Rows[i][u].ToString()); //add the elements to the stringbuilder - here the transposing is actually done

                    if (i < mydata.Rows.Count - 1)   //add a deliminator after each element to get .csv as output
                    {
                        sb.Append(',');
                    }
                }
                sb.AppendLine(); //add another line to your stringbuilder in which you will store the next column of your datatable
            }
            return sb;
        }


        //save the csv output with Format (“filename_transposed.csv”)
        public void saveFile()
        {  

            File.WriteAllText($"{System.IO.Path.GetDirectoryName(inputFileCsv)}\\{System.IO.Path.GetFileNameWithoutExtension(inputFileCsv)}_transposed{System.IO.Path.GetExtension(inputFileCsv)}", transposeCsv().ToString());

            Console.WriteLine(string.Format("{0}\n{1}", "Your csv table has been Transposed \nPlease Check your Directory:", $"{System.IO.Path.GetDirectoryName(inputFileCsv)}"));
            Console.Read();

        }

    }

    
}
