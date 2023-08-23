# Umbraco PortalApp POC

A POC for implementing our existing PortalApp in Umbraco.

## Setup of Umbraco in Local

### 1. Installing `dotnet v7`

#### Using `winget`

Open Powershell(admin) & install:

#### SDK

```bash
winget install Microsoft.DotNet.SDK.7
```

#### Runtimes

```bash
winget install Microsoft.DotNet.DesktopRuntime.7
winget install Microsoft.DotNet.AspNetCore.7
winget install Microsoft.DotNet.Runtime.7
```

> Post installation, restart the system to proceed ahead.

For manual installation, [use this link to download respective executables.](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)


### 2. Install Umbraco

### Add the `nuget` source for Umbraco

Open Powershell, and use the below command:

```bash
dotnet nuget add source "https://api.nuget.org/v3/index.json"
```

### 3. Install Umbraco Templates

```bash
dotnet new install Umbraco.Templates
```

### 3. Clone the repo in local

Clone the repo in whatever location you want in your local machine.

### 4. Build the project & Run

`cd` into the project folder and run:

```bash
dotnet build
```

Once the build is done, either run in normal mode, or development mode using either of the below commands:

```bash
dotnet run
```

```bash
dotnet watch run
```

## Features explored in the POC

* How to break down UI into heirarchy of templates
* How to use components
* Writing Custom Controllers
* Logging

## Features that DID NOT work out

* Could not send data from the controller to the view being rendered
* Was not able to write to the console, and wrote to the log file instead

> The log file can be found inside `~/umbraco/Logs/UmbracoTraceLog.xxxxxxxxxx.json`

## !!! NOTE !!!

The controller is calling an external API to fetch the *list of all services.*

Create `api.py` which will contain the view for this.

```python
import json
from portalapp.models import ServicesDim
from django.http import HttpResponse


def services(request):
    services = ServicesDim.objects.all()
    services_list = {}
    services_list['san_services'] = \
        list(services
             .filter(service_category='SAN')
             .order_by('service_id')
             .values()
             )
    services_list['hnas_services'] = \
        list(services
             .filter(service_category='HNAS')
             .order_by('service_id')
             .values()
             )
    return HttpResponse(json.dumps(services_list), content_type='applicaton/json')
```

Add inside `urls.py`:

```python
from . import api

urlpatterns = [
    ...

    path(r'api/services', api.services, name='api_services'),
]
```

And, uncomment the commented lines inside `~/Controller/ServicesController.cs`

```cs
// var responseTask = client.GetStringAsync("http://localhost:8000/portalapp/api/services");

// string response = responseTask.Result;

// var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(response);

// var loggingResponse = $"response data: {result?["san_services"][0]["service_id"]}";

// _logger.Log(LogLevel.Information, loggingResponse);
```
