# RestBuilder
Classe simples para utilizar o padrão Builder na lib [RestSharp](https://github.com/restsharp/RestSharp).

## Como usar

Executar um **POST** de dados em um endpoint.

```c#
IRestResponse<Contrato> resposta = RestBuilder.Criar()
    .ComCabecalho("App-Token", "Token123") // LICin04WKos8
    .ComCabecalho("Accept", "application/json")
    .ComCabecalho("Content-Type", "application/json")
    .ComFormatoDeSolicitacao(DataFormat.Json)
    .ComParametro("application/json; charset=utf-8", json, ParameterType.RequestBody)
    .ComMetodoHttp(Method.POST)
    .ComUriBase(BASE_URI)
    .ComUriParcial(PARCIAL_URI)
    .Gerar<Contrato>();
    
if (resposta.ErrorException != null)
{
    throw new ApplicationException(resposta.ErrorMessage, resposta.ErrorException);
}
```

Executar um **GET** de dados em um endpoint.

```c#
IRestResponse<Contrato> resposta = RestBuilder.Criar()
    .ComCabecalho("App-Token", "Token123")
    .ComCabecalho("ClienteId", "id123")
    .ComFormatoDeSolicitacao(DataFormat.Json)
    .ComMetodoHttp(Method.GET)
    .ComUriBase(BASE_URI)
    .ComUriParcial(PARCIAL_URI)
    .Gerar<Contrato>();

if (resposta.ErrorException != null)
{
    throw new ApplicationException(resposta.ErrorMessage, resposta.ErrorException);
}

return resposta.Data;
```

Para maiores informações, consulte a documentação do RestSharp: https://github.com/restsharp/RestSharp/wiki

## Licença

[Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)
