FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Test_Task_Customer_Inquiry/Test_Task_Customer_Inquiry.csproj", "Test_Task_Customer_Inquiry/"]
RUN dotnet restore "Test_Task_Customer_Inquiry/Test_Task_Customer_Inquiry.csproj"
COPY . .
WORKDIR "/src/Test_Task_Customer_Inquiry"
RUN dotnet build "Test_Task_Customer_Inquiry.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Test_Task_Customer_Inquiry.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test_Task_Customer_Inquiry.dll"]