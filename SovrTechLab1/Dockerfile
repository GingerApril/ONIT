# ���� ������
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# �������� ���� ������� � ������
COPY Laba1Marta.sln ./
COPY SovrTechLab1/*.csproj ./SovrTechLab1/

# ��������������� �����������
RUN dotnet restore Laba1Marta.sln

# �������� �� ���������
COPY . .

# ������ �������
WORKDIR /src/SovrTechLab1
RUN dotnet publish -c Release -o /app/out

# ���� ����������
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# ��������� �����
EXPOSE 80
EXPOSE 443

# ����� �����
ENTRYPOINT ["dotnet", "Laba1Marta.dll"]
