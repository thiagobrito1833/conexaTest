using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Domain.Entities
{
    public class ResultAction<T>
    {
        public bool Sucess => MessagesError.Count == 0;
        public T Result { get; private set; }
        public Dictionary<string, List<string>> Mensagens => MessagesError;
     

        public ResultAction()
        {
            MessagesError = new Dictionary<string, List<string>>();
        }

        private Dictionary<string, List<string>> MessagesError { get; set; }
      

     
        public ResultAction<T> AddError(string key, string error)
        {
            if (MessagesError == null)
            {
                MessagesError = new Dictionary<string, List<string>>();
            }

            if (!MessagesError.TryGetValue(key, out var listaDeMesagens))
            {
                listaDeMesagens = new List<string>();
                MessagesError[key] = listaDeMesagens;
            }

            if (listaDeMesagens.Contains(error)) return this;

            listaDeMesagens.Add(error);
            return this;
        }



        public ResultAction<T> AddValidation( string error)
        {
            if (MessagesError == null)
            {
                MessagesError = new Dictionary<string, List<string>>();
            }

            if (!MessagesError.TryGetValue("v01", out var listaDeMesagens))
            {
                listaDeMesagens = new List<string>();
                MessagesError["v01"] = listaDeMesagens;
            }

            if (listaDeMesagens.Contains(error)) return this;

            listaDeMesagens.Add(error);
            return this;
        }


        public ResultAction<T> SetResult(T result)
        {
            this.Result = result;
            return this;
        }

      

    }
}
