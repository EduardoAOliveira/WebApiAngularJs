using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Projeto.Services.Utils
{
    public class ValidationUtil
    {
        //método para retornar todas as mensagens de
        //erro contidas no objeto ModelState
        public static Hashtable GetErrorMessages(ModelStateDictionary state)
        {
            Hashtable errors = new Hashtable();

            //varrer o ModelStateDictionary..
            foreach(var s in state)
            {
                //verificar se ha erros de validação no ModelStateDictionary
                if(s.Value.Errors.Count > 0)
                {
                    //armazemar no hashtable
                    errors[s.Key] = s.Value.Errors
                                     .Select(e => e.ErrorMessage)
                                     .ToList();
                }
            }

            return errors; //retornando o hashtable..
        }
    }
}