using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.Models;
using SGCorpHR.DATA;

namespace SGCorpHR.BLL
{
    public class FileOperations
    {
        public Response<List<Resumes>> DisplayFiles(string filePath)
        {
           
                var repo = new FileRepository();

                var response = new Response<List<Resumes>>();

            try
            {
                response.Data = repo.GetFiles(filePath);
                if (response.Data != null)
                {
                    response.Success = true;
                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no files to display.";
                    
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                
            }
            return response;


        }
    }
}
