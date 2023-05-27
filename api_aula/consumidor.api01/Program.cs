using consumidor.api01.Model;
using Flurl.Http;
using Flurl;
using System.ComponentModel.DataAnnotations;

namespace consumidor.api01
{
    internal class Program
    { 
        static  async Task Main(string[] args)
        {
            string url = "https://localhost:7131/";

            #region objetos
            Item tarefa = new Item();
            tarefa.Id = 1;
            tarefa.Nome = "Pagar conta";
            tarefa.Finalizado = true;

            Item tarefa2 = new Item();
            tarefa2.Id = 2;
            tarefa2.Nome = "Lavar carro";
            tarefa2.Finalizado = false;
            #endregion

            //gerar uma tarefa
            string endpoint = url + "api/TarefaItems";

            #region post e listar
            Console.WriteLine("Enviado informações");
            Thread.Sleep(new TimeSpan(0, 0, 5));
            //flurl
            endpoint.PostJsonAsync(tarefa).Wait();
            endpoint.PostJsonAsync(tarefa2).Wait();

            //ler a lita
          
            Console.WriteLine("Lendo informações");
            IEnumerable<Item> listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();


            foreach (var item in listaTarefas)
            {
                Console.WriteLine(item);
            }
            #endregion


            #region alterar e listar
            //alterar
            Console.WriteLine("\nAlterando Informaçoes");
            tarefa2.Finalizado = true;
            endpoint += "/2";
            endpoint.PutJsonAsync(tarefa2).Wait();

            //ler a lista
            Console.WriteLine("Lendo informações");
            IEnumerable<Item> s = await endpoint.Replace("/2","").GetJsonAsync<IEnumerable<Item>>();

            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

            #endregion

      
            #region deletar
            //deletar
            endpoint = endpoint.Replace("2", "1");

            endpoint.DeleteAsync().Wait();



            //Ler
            var taref = await endpoint.Replace("/1", "").GetJsonAsync<IEnumerable<Item>>();

            foreach (var item in taref)
            {
                Console.WriteLine(item);
            }
            #endregion
           

            Console.WriteLine("Aperte qualquer tecla para finalizar a aplicação");
            Console.Read();
        }
    }
}