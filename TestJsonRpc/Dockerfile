FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TestJsonRpc/TestJsonRpc.csproj", "TestJsonRpc/"]
RUN dotnet restore "TestJsonRpc/TestJsonRpc.csproj"
COPY . .
WORKDIR "/src/TestJsonRpc"
RUN dotnet build "TestJsonRpc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestJsonRpc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestJsonRpc.dll"]