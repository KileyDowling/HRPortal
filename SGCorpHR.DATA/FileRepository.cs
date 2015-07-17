using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using SGCorpHR.Models;

namespace SGCorpHR.DATA
{
   public class FileRepository
   {
       public List<Resumes> GetFiles(string filePath)
       {
          
           var directory = new DirectoryInfo(filePath);
           var files = directory.GetFiles();
           if (files.Any())
           {

               var resumes = new List<Resumes>();
               foreach (var file in files)
               {
                   var resume = new Resumes();
                   resume.FilePath = file.FullName;
                   resume.FileName = file.Name;
                   resumes.Add(resume);
               }

               return resumes;
           }
           return null;

       }
   }
}
