# RestBuilder
Classe simples para utilizar o padrão Builder na lib [RestSharp](https://github.com/restsharp/RestSharp).

## Como usar

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
```

## Licença

**Apache License 2.0**
