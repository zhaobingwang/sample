#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["src-snippets/CodeSnippets.IdentityCenter/CodeSnippets.IdentityCenter.csproj", "src-snippets/CodeSnippets.IdentityCenter/"]
#RUN dotnet restore "src-snippets/CodeSnippets.IdentityCenter/CodeSnippets.IdentityCenter.csproj"
#COPY . .
#WORKDIR "/src/src-snippets/CodeSnippets.IdentityCenter"
#RUN dotnet build "CodeSnippets.IdentityCenter.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "CodeSnippets.IdentityCenter.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CodeSnippets.IdentityCenter.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80
COPY . .
ENTRYPOINT ["dotnet", "CodeSnippets.IdentityCenter.dll"]