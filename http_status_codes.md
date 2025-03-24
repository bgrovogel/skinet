# HTTP Status Codes

A comprehensive list of HTTP status codes categorized by their range.

## Table of Contents

- [1xx: Informational responses](#1xx-informational-responses)
- [2xx: Successful responses](#2xx-successful-responses)
- [3xx: Redirection messages](#3xx-redirection-messages)
- [4xx: Client errors](#4xx-client-errors)
- [5xx: Server errors](#5xx-server-errors)

---

## 🚦 **1xx: Informational responses**

These status codes indicate that the server has received the request and is processing it.

- **`100` Continue** – The server has received the request headers, and the client should proceed to send the request body.

  - **Use Case**: Typically used for large file uploads or requests where the server needs to ensure that the client is still sending the data.

- **`101` Switching Protocols** – The server is switching protocols as requested by the client.

  - **Use Case**: Seen in protocols like WebSockets or HTTP/2, where the client requests a protocol switch (e.g., upgrading from HTTP/1.1 to HTTP/2).

- **`102` Processing** – The server has received the request and is processing it, but no response is available yet (used by WebDAV).

  - **Use Case**: Useful for long-running operations like complex calculations or querying large databases.

- **`103` Early Hints** – Used to send preliminary headers before the final response (for performance optimizations).
  - **Use Case**: Used to begin loading resources ahead of the main response, reducing page load times.

---

## ✅ **2xx: Successful responses**

These status codes indicate that the request was successfully received, understood, and processed by the server.

- **`200` OK** – The request was successful, and the server returned the requested data.

  - **Use Case**: Standard response for a successful GET request, like retrieving a webpage or API data.

- **`201` Created** – The request was successful, and a resource was created (e.g., POST request).

  - **Use Case**: Used when a client successfully creates a new resource (e.g., creating a new user account or adding a new post).

- **`202` Accepted** – The request has been accepted for processing, but the processing is not complete.

  - **Use Case**: Often used for asynchronous operations like background jobs or delayed processing (e.g., a payment being processed after submission).

- **`203` Non-Authoritative Information** – The server successfully processed the request, but the returned information may be from a different source.

  - **Use Case**: Used when the server responds with data that is not directly from its own resources, such as data retrieved from a third-party service.

- **`204` No Content** – The server successfully processed the request, but there is no content to send in the response.

  - **Use Case**: Used when a request is successful but no data needs to be returned (e.g., a successful DELETE request).

- **`205` Reset Content** – The server successfully processed the request, and the client should reset the document view.

  - **Use Case**: Used in scenarios where the client needs to reset or clear its view after a successful request (e.g., clearing a form after submitting data).

- **`206` Partial Content** – The server is delivering only part of the resource due to a range header sent by the client.
  - **Use Case**: Used when downloading large files in parts (e.g., video streaming, breaking a file into chunks for download).

---

## 🔄 **3xx: Redirection messages**

These status codes indicate that the client must take some additional action to complete the request.

- **`300` Multiple Choices** – The request has more than one possible response.

  - **Use Case**: Seen when the client must choose between multiple responses, such as a webpage with language options.

- **`301` Moved Permanently** – The resource has been permanently moved to a new URL.

  - **Use Case**: Used when a webpage has permanently moved to a new URL (e.g., website redesign with a new URL structure).

- **`302` Found** – The resource is temporarily available at a different URL.

  - **Use Case**: Common in web applications when a form submission triggers a redirect to a confirmation page.

- **`303` See Other** – The response to the request can be found at another URL, using the GET method.

  - **Use Case**: After a form submission, the client should make a GET request to a different URL to fetch the result (e.g., redirects after `POST` submissions).

- **`304` Not Modified** – The resource has not been modified since the last request.

  - **Use Case**: Used for caching purposes, when the client already has the latest version of the resource.

- **`305` Use Proxy** – The requested resource must be accessed through a proxy.

  - **Use Case**: An outdated status code; rarely used today, but historically used to indicate that the client should use a proxy to access the resource.

- **`306` (Unused)** – No longer used; previously reserved for future use.

  - **Use Case**: It was reserved for a future HTTP version, but it is no longer in use.

- **`307` Temporary Redirect** – The resource has temporarily moved to a different URL (client should repeat the request to the new URL).

  - **Use Case**: Often used for temporarily moving a resource or during server maintenance, requiring the client to retry at a different location.

- **`308` Permanent Redirect** – The resource has permanently moved to a new URL (client should update its stored URL).
  - **Use Case**: Used when a resource has permanently moved, and the client should update its URL.

---

## 🚫 **4xx: Client Errors**

These status codes indicate that the client seems to have made an error.

- **`400` Bad Request** – The server could not understand the request due to malformed syntax.

  - **Use Case**: Happens when the client sends invalid or improperly formatted data, like an incorrectly structured URL or missing required parameters.

- **`401` Unauthorized** – Authentication is required and has failed or has not been provided.

  - **Use Case**: Triggered when an API request is made without proper authentication (e.g., missing API key or invalid credentials).

- **`402` Payment Required** – Reserved for future use, meant for digital payment systems.

  - **Use Case**: Intended for use with APIs or services that require payments, but it's not in wide use.

- **`403` Forbidden** – The server understands the request, but it refuses to authorize it.

  - **Use Case**: The user might not have necessary permissions (e.g., trying to access a restricted resource).

- **`404` Not Found** – The requested resource could not be found on the server.

  - **Use Case**: Often triggered when a user tries to access a page that doesn’t exist (e.g., broken link).

- **`405` Method Not Allowed** – The request method is not supported for the specified resource.

  - **Use Case**: Happens when the client attempts to perform an unsupported action on a resource (e.g., using `GET` when the resource only supports `POST`).

- **`406` Not Acceptable** – The server cannot produce a response matching the criteria specified by the client in the `Accept` header.

  - **Use Case**: Occurs when a client specifies a content type (e.g., JSON or XML) that the server can't return.

- **`407` Proxy Authentication Required** – The client must authenticate itself to use the proxy.

  - **Use Case**: Occurs when a request goes through a proxy that requires authentication.

- **`408` Request Timeout** – The server timed out waiting for the request.

  - **Use Case**: Triggered when a client takes too long to send a request, often caused by network issues or large uploads.

- **`409` Conflict** – The request could not be processed due to a conflict with the current state of the resource.

  - **Use Case**: Happens when there is a conflict (e.g., when two users try to modify the same resource at the same time).

- **`410` Gone** – The resource is no longer available and will not be available again.

  - **Use Case**: Indicates that the resource has been permanently removed, and it’s not coming back (e.g., deleted content).

- **`411` Length Required** – The request did not specify the length of its content, and the server requires it.

  - **Use Case**: Happens when a request that contains a body (like `POST`) doesn’t include a `Content-Length` header.

- **`412` Precondition Failed** – A precondition specified in the request (e.g., `If-Match`) failed.

  - **Use Case**: Triggered when the client’s request conditions are not met (e.g., mismatch between the entity tag in the request and the resource).

- **`413` Payload Too Large** – The request entity is too large for the server to process.

  - **Use Case**: Happens when a client sends a file or data that exceeds the server's configured maximum size.

- **`414` URI Too Long** – The URI provided is too long for the server to process.

  - **Use Case**: Triggered when the client sends a URI that is too long (e.g., a long query string).

- **`415` Unsupported Media Type** – The request entity's media type is not supported by the server.

  - **Use Case**: Occurs when the server cannot process the request because it does not support the content type.

- **`416` Range Not Satisfiable** – The range specified in the request can’t be fulfilled.

  - **Use Case**: Happens when the client requests a part of a resource (e.g., a byte range), but the resource does not support that range.

- **`417` Expectation Failed** – The server cannot meet the requirements of the `Expect` header.

  - **Use Case**: Triggered when the server cannot fulfill expectations defined by the client (e.g., expecting a certain response code).

- **`418` I'm a teapot** – This is an April Fools' joke response code defined in **RFC 2324**.

  - **Use Case**: A playful code used in the HTTP “teapot” joke protocol.

- **`421` Misdirected Request** – The request was directed at a server that is not able to produce a response.

  - **Use Case**: Occurs when the client sends a request to the wrong server, such as when using a load balancer incorrectly.

- **`422` Unprocessable Entity** – The server understands the content type of the request entity, but the request was unable to be processed.

  - **Use Case**: Used in WebDAV or REST APIs when the request contains valid syntax but is semantically incorrect (e.g., an invalid input value).

- **`423` Locked** – The resource that is being accessed is locked.

  - **Use Case**: Typically used in WebDAV when the resource is locked due to some kind of exclusive editing or other reasons.

- **`424` Failed Dependency** – The request failed due to a failure of a previous request (in a multi-request transaction).

  - **Use Case**: Happens when one request depends on the success of a previous request, but that previous request has failed.

- **`425` Too Early** – The server is unwilling to risk processing a request that might be replayed.

  - **Use Case**: Used in security contexts to prevent attacks such as replay attacks (e.g., when the client sends a request too soon after the last).

- **`426` Upgrade Required** – The client should switch to a different protocol, such as TLS/1.0.

  - **Use Case**: Occurs when the server requires the client to switch to a more secure protocol (e.g., HTTP to HTTPS).

- **`427` Unassigned** – Reserved for future use by the IETF (currently unused).

  - **Use Case**: Not in use as of now.

- **`428` Precondition Required** – The origin server requires the request to be conditional.

  - **Use Case**: Used to prevent the "lost update" problem, requiring the client to send an `If-Match` or `If-None-Match` header.

- **`429` Too Many Requests** – The user has sent too many requests in a given amount of time.

  - **Use Case**: Often seen in rate-limited APIs when a user exceeds the maximum number of allowed requests.

- **`430` Unassigned** – Reserved for future use by the IETF (currently unused).

  - **Use Case**: Not in use as of now.

- **`431` Request Header Fields Too Large** – The server is unwilling to process the request because one or more request header fields are too large.

  - **Use Case**: Triggered when the headers sent in a request are too large for the server to handle, often due to too many cookies or long header values.

- **`451` Unavailable For Legal Reasons** – The server is refusing to respond to the request for legal reasons.
  - **Use Case**: Typically used when content is blocked due to legal restrictions, such as government censorship.

---

## ⚠️ **5xx: Server errors**

These status codes indicate that the server failed to fulfill a valid request.

- **`500` Internal Server Error** – The server encountered an unexpected condition that prevented it from fulfilling the request.

  - **Use Case**: A generic error when the server encounters a problem (e.g., database connection issues).

- **`501` Not Implemented** – The server does not support the functionality required to fulfill the request.

  - **Use Case**: The server may not recognize the request method or feature, such as when an API endpoint isn’t supported.

- **`502` Bad Gateway** – The server received an invalid response from the upstream server.

  - **Use Case**: Seen when a reverse proxy or gateway server receives an invalid response (e.g., from an external API).

- **`503` Service Unavailable** – The server is currently unable to handle the request due to temporary overload or maintenance.

  - **Use Case**: Happens during maintenance windows or temporary server overload.

- **`504` Gateway Timeout** – The server did not receive a timely response from an upstream server.

  - **Use Case**: Triggered when a reverse proxy or gateway server times out waiting for an external server.

- **`505` HTTP Version Not Supported** – The server does not support the HTTP protocol version that was used in the request.

  - **Use Case**: Happens when the server does not support the version of HTTP requested by the client.

- **`506` Variant Also Negotiates** – The server has an internal configuration error: it is configured to engage in content negotiation, but a variant itself is selected.

  - **Use Case**: A very rare error that signals a misconfiguration in content negotiation mechanisms.

- **`507` Insufficient Storage** – The server is unable to store the representation needed to complete the request.

  - **Use Case**: Often seen when the server’s storage is full, and it cannot process the request.

- **`508` Loop Detected** – The server detected an infinite loop while processing a request (used by WebDAV).

  - **Use Case**: Occurs when a request causes a loop, such as a redirect loop.

- **`510` Not Extended** – The server requires further extensions to fulfill the request.

  - **Use Case**: Indicates that the server needs more information or configuration to process the request.

- **`511` Network Authentication Required** – The client needs to authenticate to gain network access.
  - **Use Case**: Happens when trying to access the internet behind a captive portal (e.g., logging into a public Wi-Fi network).
