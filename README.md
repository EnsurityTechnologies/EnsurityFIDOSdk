# FidoClientSdk

**.NET SDK Client for FIDO API**

[![NuGet](https://img.shields.io/nuget/v/FidoClientSdk.svg?style=flat-square)](https://www.nuget.org/packages/FidoClientSdk/)  
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)  

---

## Overview

FidoClientSdk is a .NET 8 class library that provides a strongly-typed client to interact with the FIDO (Fast IDentity Online) API.  
It simplifies integration with FIDO authentication flows by wrapping API endpoints into easy-to-use async methods.

---

## Features

- Support for **MakeCredentialRequest** and **MakeCredentialResponse** APIs
- Support for **GetAssertionRequest** and **GetAssertionResponse** APIs
- Strongly typed request/response models
- `HttpClient`-based service with DI-friendly design
- Automatic JSON (de)serialization
- BSON attributes support for MongoDB compatibility

---

## Installation

Install via NuGet Package Manager Console:

```powershell
Install-Package FidoClientSdk
