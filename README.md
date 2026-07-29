# Meyn.Utilities

[![NuGet](https://img.shields.io/nuget/v/Meyn.Utilities.svg)](https://www.nuget.org/packages/Meyn.Utilities)
[![GitHub](https://img.shields.io/github/license/prmeyn/CommonUtilities)](https://github.com/prmeyn/CommonUtilities/blob/main/LICENSE)

A collection of common utilities and extensions for .NET applications. Targets **.NET 10**.

**Repository:** [https://github.com/prmeyn/CommonUtilities](https://github.com/prmeyn/CommonUtilities)

## Installation

```bash
dotnet add package Meyn.Utilities
```

All public types live under the `Meyn.Utilities` namespace (HTTP extensions are in `Meyn.Utilities.Extensions`).

## Features

### Cryptography Utilities (`CryptoUtils`)

Provides helper methods for random number generation, hashing, and encoding. Random digits are produced with a cryptographically secure RNG and are uniformly distributed (no modulo bias).

```csharp
using Meyn.Utilities;

// Generate a cryptographically secure random numeric string of a specific length
string randomNum = CryptoUtils.GetRandomNumber(6); // e.g., "402917"

// Compute SHA-512 hash
string hash = CryptoUtils.ComputeSha512Hash("password123");

// Base64 Encoding/Decoding
string base64 = CryptoUtils.ToBase64("Hello World");
string plain = CryptoUtils.FromBase64(base64);
```

### General Utilities (`Utils`)

#### Template Substitution

Replace placeholders in a string with values from a dictionary. Placeholders should be in the format `##Key##`. If the template is empty or whitespace, a newline-separated list of the resolved values is returned instead. Passing a `null` dictionary throws `ArgumentNullException`.

```csharp
using Meyn.Utilities;

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

Retrieves the client's public IP address from `HttpContext`. It checks the `CF-Connecting-IP` (Cloudflare) and `X-Forwarded-For` headers, then falls back to `Connection.RemoteIpAddress`, skipping loopback addresses (`::1`, `127.0.0.1`). Returns `null` when no non-loopback address can be determined.

```csharp
using Meyn.Utilities.Extensions;

// Inside a Controller or Middleware
string? ipAddress = HttpContext.GetPublicIP();
```