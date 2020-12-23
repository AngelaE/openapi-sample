# Generate BookApi Typescript Client 

The Book API client is generated with autorest, see https://aka.ms/autorest for details.

To generate the client for this project run ```npm run generate-client```

## AutoRest Client Generator Configuration
``` yaml
use-extension:
  "@microsoft.azure/autorest.modeler": "2.3.55"
  "@microsoft.azure/autorest.typescript": "4.2.4"
  
version: 3.0.6322 #autorest version
input-file: http://localhost:5001/swagger/v1/swagger.json
output-folder: .
typescript: 
  source-code-folder-path: ./src/book-api-client
  override-client-name: BookApiClient
  client-side-validation: false # disable client side validation of constraints
  enum-types: true
```