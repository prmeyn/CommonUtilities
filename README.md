# Meyn.Utilities

A collection of common utilities and extensions for .NET applications.

## Installation

```bash
dotnet add package Meyn.Utilities
```

## Features

### Cryptography Utilities (`CryptoUtils`)

Provides helper methods for random number generation, hashing, and encoding.

```csharp
using Common.Utilities;

// Generate a random numeric string of a specific length
string randomNum = CryptoUtils.GetRandomNumber(6); // e.g., "123456"

// Compute SHA-512 hash
string hash = CryptoUtils.ComputeSha512Hash("password123");

// Base64 Encoding/Decoding
string base64 = CryptoUtils.ToBase64("Hello World");
string plain = CryptoUtils.FromBase64(base64);
```

### General Utilities (`Utils`)

#### Template Substitution

Replace placeholders in a string with values from a dictionary. Placeholders should be in the format `##Key##`.

```csharp
using Common.Utilities;

var template = "Hello ##Name##, welcome to ##City##!";
var args = new Dictionary<string, string>
{
    { "Name", "John" },
    { "City", "New York" }
};

string result = Utils.SubstituteTemplate(template, args);
// Output: "Hello John, welcome to New York!"
```

### HTTP Extensions (`HttpContextExtensions`)

#### Get Public IP

Retrieves the client's public IP address from `HttpContext`, checking various headers (Cloudflare, X-Forwarded-For) and handling local loopback addresses.

```csharp
using Meyn.Utilities.Extensions;

// Inside a Controller or Middleware
string ipAddress = HttpContext.GetPublicIP();
```