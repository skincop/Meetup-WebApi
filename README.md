# Meetup-WebApi #
## Используемые технологии ##
+ Asp Net Core 6
+ EF CORE
+ MS SQL Server
+ AutoMapper
+ MediatoR+CQRS
+ FluentValidation
+ Jwtbearer
+ Swagger

## Инструкция по запуску ##
1. Сменить в файле Meetups.WebApi/appsettings.json название сервера бд
2. Перейти в директорию Meetups.WebApi
3. Выполнить dotnet run через терминал


## Использование запросов ##
Методы контроллера Meetup требует наличие JWT-токена,по этому перед использованием:
1 зарегестрировать пользователя через запрос   api/auth/register.
2 Получить jwt-токен через запрос api/auth/auth.
3 Добавить заголовок Authorization:Bearer + сгенерированый токен.
