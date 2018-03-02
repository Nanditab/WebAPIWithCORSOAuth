# WebAPIWithCorsOAuth
This is an example to learn about Web API security. I have kept to simple so that its easy to understand how CORS, Authentication and Authorization works.
It doesnt not have database so it easy to run the project.
# Components
It has three component
1. WebAPI - provides product services [http://localhost:49728]
2. External Site -Supported - Web site which WebAPI can communicate. [http://localhost:54726/]
3. External Site Unsupported - Web site which WebAPI doesnt support. [http://localhost:63898/]

# Service API
CORS Example

| API URI | External Site - Supported |  External Site - Unsupported | Comments
| --- | --- | --- | --- |
| GetProducts() ->`http://localhost:49728/api/products` | Yes | Yes | All origin request allowed |
|GetProductById -> http://localhost:49728/api/products/1` | Yes | Yes | All origin request allowed |
|PutProduct -> Update on website` | Yes  | NO | Only allowed for supported website |

Security
| API URI | External Site - Supported |  External Site - Unsupported | Comments
| --- | --- | --- | --- |
| GetProducts() ->`http://localhost:49728/api/products` | Yes | No | Need Authorization Cookie. |