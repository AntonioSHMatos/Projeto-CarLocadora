using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.RabbitMQ
{
    public interface IRabbitMQNegocio
    {
        void PublicarMensagem(object conteudo, string exchange = "", string fila = "");
    }
}
