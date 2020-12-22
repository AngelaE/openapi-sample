# Generate BookApi Client 

The Book API client is generated with autorest, see https://aka.ms/autorest for details.

To generate the client for this project:
1. run ```npm install``` in the root folder of the repository
2. run the npm task to generate the client: ```npm run generate-book-client```

## AutoRest Client Generator Configuration
``` yaml
use-extension:
  "@microsoft.azure/autorest.modeler": "2.3.55"
  "@microsoft.azure/autorest.csharp": "2.3.82"

version: 3.0.6247 #autorest version
input-file: http://localhost:5001/swagger/v1/swagger.json
output-folder: .
csharp: 
  namespace: Clients 
  override-client-name: BookApiClient
  client-side-validation: false # disable client side validation of constraints
  add-credentials: true
```
