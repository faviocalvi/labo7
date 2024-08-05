Laboratio 7

1 Agregar tres inputs, una para el nombre, el apellido y el correo electrónico, agregue un botón para enviar la información y guardar la información en una estructura de datos y use un ListView para mostrarla.
    1.1. se utilizo un singleton para la base de datos para poder almacenar los estudiantes registrados, el singleton se configuro en App.xaml.cs y se lo mando a las viewmodel con el metodoOnLaunched(LaunchActivatedEventArgs args)
2 Agregar otro input para buscar por correo electrónico y agregue botones para ordenar de forma ascendente o descendente, use LINQ para filtrar y buscar; añada un resumen en la parte inferior de ListView que muestra el total de usuarios.
    2.1. se crearon 3 formas de busqueda con nombre apellido y correo, usando la estructura LINQ en el metodo SearchStudents()
3 Usando el patrón observador implemente un sistema de notificación que reacciona cada vez que hay una acción en la aplicación, por ejemplo, cuando se agrega un usuario se muestra un mensaje que indica la acción que acaba de ocurrir.
    3.1. se configuro el sistema de notificaciones con las clases IObserver, Subject y NotificationObservers para que cada que una accion se realice se reescriba el mensaje para luego mostrarlo en la vista con el nombre NotificationArea
4 Agregue otras acciones para activar la notificación, como ordenar o buscar.
    4.1. se agregaron notificaciones a las funciones de ordenamiento ascendente y descendete; por nombre, por apellido y por email; y a la creacion de estudiante 
5 Manejar posibles excepciones respecto al procesamiento de usuarios.
    5.1. se manejan las excepciones en la creacion y busqueda de usuarios
6 Guardar los mensajes de error en una estructura de pila y mostrarlos al presionar otro botón junto con la hora en que sucedió.
    6.1.1 se creao la clase ErrorLogger para almacenar en forma de pila todos los errores manejados en el punto 4 con la linea de codigo _errorLogger.LogError($"Error sorting students: {ex.Message}");
