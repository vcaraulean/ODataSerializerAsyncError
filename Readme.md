# Sample project to reproduce `$metadata` endpoint issue

To reproduce, hit `/odata/$metadata` endpoint few times.

Exception details:

```
fail: Microsoft.AspNetCore.Server.Kestrel[13]
      Connection id "0HN74EUNG3QG9", Request id "0HN74EUNG3QG9:00000001": An unhandled exception was thrown by the application.
      System.InvalidOperationException: An asynchronous operation is already in progress.
         at System.Xml.XmlAsyncCheckWriter.CheckAsync()
         at System.Xml.XmlAsyncCheckWriter.Flush()
         at Microsoft.OData.ODataMetadataOutputContext.Dispose(Boolean disposing)
         at Microsoft.OData.ODataOutputContext.Dispose()
         at Microsoft.OData.ODataMessageWriter.Dispose(Boolean disposing)
         at Microsoft.OData.ODataMessageWriter.Dispose()
         at Microsoft.AspNetCore.OData.Formatter.ODataOutputFormatterHelper.WriteToStreamAsync(Type type, Object value, IEdmModel model, ODataVersion version, Uri baseAddress, MediaTypeHeaderValue contentType, HttpRequest request, IHeaderDictionary requestHeaders, IODataSerializerProvider serializerProvider)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeResultAsync>g__Logged|22_0(ResourceInvoker invoker, IActionResult result)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeResultFilters>g__Awaited|28_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Logged|17_1(ResourceInvoker invoker)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Logged|17_1(ResourceInvoker invoker)
         at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|7_0(Endpoint endpoint, Task requestTask, ILogger logger)
         at Microsoft.AspNetCore.OData.Routing.ODataRouteDebugMiddleware.Invoke(HttpContext context)
         at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
         at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
         at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
```

Sometimes error is different:
```
System.InvalidOperationException
Token EndAttribute in state Element Start Tag would result in an invalid XML document.
   at System.Xml.XmlWellFormedWriter.ThrowInvalidStateTransition(Token token, State currentState)
   at System.Xml.XmlWellFormedWriter.AdvanceStateAsync(Token token)
   at System.Xml.XmlWellFormedWriter.WriteEndAttributeAsync()
   at System.Xml.XmlWellFormedWriter.AdvanceStateAsync(Token token)
   at System.Xml.XmlWellFormedWriter.WriteEndElementAsync()
   at System.Xml.XmlAsyncCheckWriter.WriteEndElementAsync()
   at Microsoft.OData.Edm.Csdl.Serialization.EdmModelCsdlSchemaXmlWriter.WriteEndElementAsync()
   at Microsoft.OData.Edm.Csdl.Serialization.EdmModelCsdlSerializationVisitor.VisitEdmSchemaAsync(EdmSchema element, IEnumerable`1 mappings)
   at Microsoft.OData.Edm.Csdl.CsdlXmlWriter.WriteSchemasAsync()
   at Microsoft.OData.Edm.Csdl.CsdlXmlWriter.WriteODataCsdlAsync()
   at Microsoft.OData.Edm.Csdl.CsdlXmlWriter.WriteCsdlAsync()
   at Microsoft.OData.Edm.Csdl.CsdlWriter.TryWriteCsdlAsync(IEdmModel model, XmlWriter writer, CsdlTarget target, CsdlXmlWriterSettings writerSettings)
   at Microsoft.OData.ODataMetadataOutputContext.WriteMetadataDocumentImplementationAsync()
   at Microsoft.OData.ODataMetadataOutputContext.WriteMetadataDocumentAsync()
   at Microsoft.OData.ODataMessageWriter.WriteToOutputAsync(ODataPayloadKind payloadKind, Func`2 writeAsyncAction)
   at Microsoft.AspNetCore.OData.Formatter.Serialization.ODataMetadataSerializer.WriteObjectAsync(Object graph, Type type, ODataMessageWriter messageWriter, ODataSerializerContext writeContext)
   at Microsoft.AspNetCore.OData.Formatter.ODataOutputFormatterHelper.WriteToStreamAsync(Type type, Object value, IEdmModel model, ODataVersion version, Uri baseAddress, MediaTypeHeaderValue contentType, HttpRequest request, IHeaderDictionary requestHeaders, IODataSerializerProvider serializerProvider)
```