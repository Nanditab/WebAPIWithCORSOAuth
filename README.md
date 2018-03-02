# WebAPIWithCorsOAuth
This is an example to learn about Web API security. I have kept to simple so that its easy to understand how CORS, OAuth, Authentication and Authorization works.
It doesnt not have database so it easy to run the project.
# Components
Solution has three components
1. WebAPI - provides product services, runs @ [http://localhost:49728]
2. External Site -Supported - An external domain website. Web API has CORS setting to supporte this site. 
  For CORS Example - [http://localhost:54726/]
  For OAuth Example - [http://localhost:54726/Accounts/Index]
3. External Site Unsupported - Another external domain website to illustrate CORS settings. Web API has NO CORS setting to supporte this site. Hence can only do operation allowed for all origins.
  For CORS Example - [http://localhost:63898/]
  For OAuth Example - http://localhost:63898/Accounts/Index

# Service API
CORS Example

| API URI | External Site - Supported |  External Site - Unsupported | Comments
| --- | --- | --- | --- |
| GetProducts() ->`http://localhost:49728/api/products` | Yes | Yes | API has CORS setting to allow all origin |
| GetProductById -> http://localhost:49728/api/products/1` | Yes | Yes | API has CORS setting to allow all origin |
|  PutProduct -> Update on website` | Yes  | NO | API has CORS setting to allow only "External Site -Supported" |

OAuth Example

| Service | External Site - Supported |  External Site - Unsupported | Comments
| --- | --- | --- | --- |
| GetProductWithPrice without login ->`http://localhost:49728/api/ProductWithPrice` | No | No | Need OAuth token. |
| Login ->`http://localhost:49728/token` | Yes | No | OAuth [very filmsy] security configuration to allow only "External Site -Supported" |
| GetProductWithPrice after login` | Yes | No | Need OAuth cookie |

# Data
The data is stored in static list. You can find it
Users -> Accounts Controller Constructor
Product -> Products Controller Constructor

# references

https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/
http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/
https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-oauth-20-authorization-server

