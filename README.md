# DigitalFactory
Este es un proyecto para ser desarrollado como ejercicio práctico para Digital Factory

- Se utilizaMicrosoft.EntityFrameworkCore.InMemory faciliar la realización de pruebas unitarias y para facilitar el desarrollo. Aunque para pruebas unitarias,
tambien se puede realizar con Mocks puede ser con RhinoMocks o con Moq
- Aunque no se utilizó EF Code First como opción de mejora se puede crear un nuevo repositorio y se inyecta esta dependencia en el modelo, para que pueda utilizar SQlServer,
pero para efectos prácticos en este ejercicio se utilizó InMemory
- Para pruebas unitarias se utiliza NUnit como framework de Unite Test, se realizan pruebas sobre facade y sobre el Controller
- Para correr la aplicación ingresar los siguentes comandos dotnet restore y luego dotnet run desde la carpeta ApplicationDigitalFactory donde se encuentra el proyecto
- Para ejecutar las pruebas unitarias ingresar el comando dotnet test ubicandose en la carpeta UnitTestDigital
- No se utiliza el boilerplate sugerido.