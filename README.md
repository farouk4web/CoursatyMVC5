# Coursaty – Course Aggregation Platform

Coursaty is a **web platform** designed to organize and display courses in one place, with **role-based access control** for three user types:  
- **Admins**: Manage users, assign team roles, and oversee platform content.  
- **Work Team Members**: Add and edit courses.  
- **Normal Users**: Browse and view available courses.  

The platform was built to **streamline course discovery and content management**, with features supporting **scalability** and **user interaction**.  
It is designed with **extensibility** in mind, offering a clear separation of permissions and a clean, intuitive interface.

---

## 🚀 Features

- **Role-Based Access Control** for Admins, Work Team Members, and Normal Users.
- **Course Management**: Add, edit, and organize courses.
- **User Management** (Admins only): Assign roles and manage accounts.
- **Scalable Design**: Built to support growing course catalogs.
- **Clean & Intuitive Interface** with responsive design.

---

## 🛠️ Tech Stack

| Technology              | Purpose                                 |
|-------------------------|-----------------------------------------|
| ASP.NET MVC              | Core web application framework         |
| Entity Framework         | ORM for database access                |
| Microsoft SQL Server     | Relational database                    |
| Bootstrap                | Responsive UI design                   |
| jQuery & JavaScript      | Interactive client-side functionality  |
| HTML5 & CSS3             | Markup and styling                     |

---

## 📂 Project Structure

```
Coursaty/
│── Controllers/       # MVC controllers for handling requests
│── Models/            # Entity and ViewModel classes
│── Views/             # Razor views for the UI
│── Scripts/           # jQuery, JavaScript files
│── Content/           # CSS, Bootstrap styles
│── App_Start/         # Route config, filters, etc.
│── Web.config         # Application configuration
```

---

## ⚙️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/farouk4web/Coursaty.git
   ```

2. **Open in Visual Studio**
   - Open the `.sln` file.

3. **Configure the Database**
   - Update the `connectionStrings` section in `Web.config` with your SQL Server instance.
   - Run the initial migrations or SQL scripts to create the database schema.

4. **Build & Run**
   - Press `F5` in Visual Studio or run via IIS Express.

---

## 🔐 User Roles

- **Admin**  
  Manage users, assign roles, and oversee platform content.
- **Work Team Member**  
  Add and edit courses.
- **Normal User**  
  Browse and view courses.

---

## 📸 Screenshots

*(Add screenshots of your platform here for a better visual overview.)*

---

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
