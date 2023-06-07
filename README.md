# FlowDotnetSDK

This repository will on flow-dotnet-sdk and explain implementation layer of flow-dotnet-sdk

## ✨ Getting Started

## Clone Project and Install Dependencies

- ### Clone the project

  ```sh
      git clone https://github.com/ObjectPlayer/FlowDotnetSDK.git
  ```

- ### Install Dependencies

  _🛠 This project requires `dotnet` or above._ See: [Dotnet installation](https://learn.microsoft.com/en-us/dotnet/core/install)

  _🛠 This project requires `flow-dotnet-sdk` or above._ See: [Flow DOtnet Sdk](https://github.com/tyronbrand/flow.net)

- ### Compile and create build

  #### For Ubutu and VS-Code

      - add binary file path in launch.json e.g:
      ```
        "configurations": [
          {
            ...
            "program": "${workspaceFolder}/FlowScript/bin/Debug/net6.0/FlowScript.dll",
            ...
          }
      ```

  #### Create build

        ```
            dotnet build
        ```

  #### Run Application

        ```
            dotnet run
        ```
