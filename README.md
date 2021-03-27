
[![.NET Build & Unit Test](https://github.com/adearriba/Zeleris.NET/actions/workflows/dotnet.yml/badge.svg)](https://github.com/adearriba/Zeleris.NET/actions/workflows/dotnet.yml)

# Zeleris.NET
 A .NET library to connect to Zeleris API.

## Zeleris Client
To interact with Zeleris API, you need to create a ``ZelerisClient`` with the user and password provided by Zeleris.

```csharp
var client  =  new  ZelerisClient(apiUser, apiPassword);
```

This client has different methods that accept a request type:
|Method|Request|Description|
|--|--|--|
|GetDocument|DocumentInformationRequest|Retrieve information from an order|
|CreateDocument|CreateDocumentRequest|Place a new order|
|ModifyDocument|ModifyDocumentRequest|Change information of an order|
|CancelDocument|CancelDocumentRequest|Cancel an order|
|GetDocumentTracking|DocumentTrackingRequest|Get tracking information of an order|

Each type of request uses the ``Builder Pattern`` to build the required structure needed to interact with the API. For example, the ``CancelDocumentRequest`` would be built like follows:

```csharp
// The serializer is needed to serialize the request
var serializer = new  XmlComponentSerializer();

//Building the request
var request = new CancelDocumentRequest(serializer);
request.AddDocumentId(documentId)
	.AddClientId(_settings.ClientId)
	.AddDocumentNumber(documentNumber)
	.AddDocumentTypeId("ENT");
```

ZelerisClient will invoke the ``BuildRequest()`` method to create the XML representation of the request and send it to the API.

So, in order to cancel an order (besides Zeleris restrictions based on order status), you would need to do it this way:

```csharp
var client  =  new  ZelerisClient(apiUser, apiPassword);
var serializer = new  XmlComponentSerializer();

var request = new CancelDocumentRequest(serializer);
request.AddDocumentId(documentId)
	.AddClientId(_settings.ClientId)
	.AddDocumentNumber(documentNumber)
	.AddDocumentTypeId("ENT");

// Async method
var response = await client.CancelDocument(request);
```

This will return a ``CancelDocumentResponse`` which will have all the information returned by the API. Each response type will have their own structure.
