using System;
using RestSharp;

namespace Utils.RestBuilder
{
	public class RestBuilder
	{
		private IRestClient cliente;
		private IRestRequest requisicao;

		private RestBuilder() { }

		public static RestBuilder Criar()
		{
			RestBuilder builder = new RestBuilder();
			builder.cliente = new RestClient();
			builder.requisicao = new RestRequest();
            builder.requisicao.JsonSerializer.ContentType = "application/json; charset=utf-8";

			return builder;
		}

		public IRestResponse<T> Gerar<T>() where T : new()
		{
			return this.cliente.Execute<T>(this.requisicao);
		}

		public IRestResponse Gerar()
		{
			return this.cliente.Execute(this.requisicao);
		}

		public Uri GerarUri()
		{
			return this.cliente.BuildUri(this.requisicao);
		}

		public RestBuilder ComUriBase(string uri)
		{
			this.cliente.BaseUrl = new Uri(uri);
			return this;
		}

		public RestBuilder ComUriParcial(string uri)
		{
			this.requisicao.Resource = uri;
			return this;
		}

		public RestBuilder ComCabecalho(string nome, string valor)
		{
			this.requisicao.AddHeader(nome, valor);
			return this;
		}

		public RestBuilder ComFormatoDeSolicitacao(DataFormat formato)
		{
			this.requisicao.RequestFormat = formato;
			return this;
		}

		public RestBuilder ComMetodoHttp(Method metodo)
		{
			this.requisicao.Method = metodo;
			return this;
		}

		public RestBuilder ComParametro(string nome, object valor)
		{
			this.requisicao.AddParameter(nome, valor);
			return this;
		}

        public RestBuilder ComParametro(string nome, object valor, ParameterType tipo)
        {
            this.requisicao.AddParameter(nome, valor, tipo);
            return this;
        }

		public RestBuilder ComSegmentoNaUri(string nome, string valor)
		{
			this.requisicao.AddUrlSegment(nome, valor);
			return this;
		}

		public RestBuilder ComCorpo(object corpo)
		{
			this.requisicao.AddBody(corpo);
			return this;
		}

        public RestBuilder ComCorpoJson(object corpo)
        {
            this.requisicao.AddJsonBody(corpo);
            return this;
        }
	}
}

