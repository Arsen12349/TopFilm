FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

EXPOSE 80
ENV ASPNETCORE_URLS http://+:80

COPY TopFilms/bin/Debug/net5.0 .

ENTRYPOINT ["dotnet", "TopFilms.dll"]