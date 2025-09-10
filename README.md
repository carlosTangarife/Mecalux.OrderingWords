# 📝 Mecalux Word Ordering API

A **comprehensive text processing solution** that provides word ordering and statistical analysis capabilities. This project demonstrates modern software architecture principles with a clean separation of concerns between frontend and backend components.

## 🎯 Features

### **📊 Text Analysis**
- **Word Count**: Accurate counting of words in any text
- **Space Analysis**: Detection and counting of spaces (including leading/trailing)
- **Hyphen Detection**: Identification and counting of hyphens in text
- **Statistical Reports**: Comprehensive text metrics

### **🔤 Word Ordering**
- **Alphabetical Ascending**: Sort words from A-Z
- **Alphabetical Descending**: Sort words from Z-A  
- **Length Ascending**: Sort words by length (shortest first)
- **Flexible Input**: Support for any text format (phrases, paragraphs, books)

### **🛡️ Robust Validation**
- Input length limits (max 10,000 characters)
- Data sanitization and validation
- Comprehensive error handling
- Structured logging with Serilog

## 🏗️ Architecture & Technology Stack

### **Backend (.NET 8 LTS)**
- **Framework**: ASP.NET Core Web API
- **Architecture**: Clean Architecture with DDD principles
- **Patterns**: Strategy Pattern, Repository Pattern, Dependency Injection
- **Logging**: Structured logging with Serilog (Console + File)
- **Documentation**: Swagger/OpenAPI with comprehensive schemas
- **Validation**: Data Annotations with automatic ModelState validation
- **Error Handling**: Global exception middleware with structured responses
- **Health Checks**: Built-in health monitoring at `/health`

### **Frontend (Angular 12)**
- **Framework**: Angular with TypeScript
- **Architecture**: Feature-based modular structure
- **UI Framework**: Bootstrap 5 for responsive design
- **State Management**: RxJS for reactive programming
- **HTTP Client**: Angular HttpClient with interceptors

### **Development Practices**
- ✅ **SOLID Principles**
- ✅ **Clean Code Standards**
- ✅ **Unit Testing** (MSTest + Moq)
- ✅ **Dependency Injection**
- ✅ **API Versioning** (`/api/v1/`)
- ✅ **CORS Security** (Restricted origins)
- ✅ **Input Validation**

## 🚀 Quick Start

### **Prerequisites**
- .NET 8 SDK
- Node.js v14.17.1+ and npm 6.14.13+
- Git

### **🔧 Backend Setup**
```bash
# Clone the repository
git clone <repository-url>
cd Mecalux.OrderingWords

# Navigate to API project
cd src/Mecalux.OrderingWords.Api

# Restore dependencies and run
dotnet restore
dotnet run
```

**🌐 Backend will be available at:**
- **API**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`
- **Health Check**: `https://localhost:5001/health`

### **🎨 Frontend Setup**
```bash
# Navigate to Angular project
cd ui/OrderingWords

# Install dependencies
npm install

# Start development server
npm run start
```

**🌐 Frontend will be available at:**
- **Application**: `http://localhost:4200`

## 📡 API Endpoints

### **📊 Text Analysis**
```http
POST /api/v1/OrderWords/GetStatic
Content-Type: application/json

{
  "textToAnalyze": "Hello world, this is a sample text!"
}
```

**Response:**
```json
{
  "wordQuantity": 7,
  "spacesQuantity": 6,
  "hyphensQuantity": 0
}
```

### **🔤 Word Ordering**
```http
POST /api/v1/OrderWords/GetOrderedText
Content-Type: application/json

{
  "textToOrder": "zebra apple banana",
  "orderOptions": 0
}
```

**Response:**
```json
["apple", "banana", "zebra"]
```

### **⚙️ Order Options**
```http
GET /api/v1/OrderWords/GetOrderOptions
```

**Response:**
```json
[
  {"key": "AlphabeticAsc", "value": 0},
  {"key": "AlphabeticDesc", "value": 1},
  {"key": "LengthAsc", "value": 2}
]
```

## 🧪 Testing

### **Run Unit Tests**
```bash
cd test/Mecalux.OrderingWords.test
dotnet test
```

### **Test Coverage**
- Controllers: ✅ Comprehensive test suite
- Services: ✅ Business logic validation
- Mocking: ✅ Complete isolation with Moq

## 📁 Project Structure

```
Mecalux.OrderingWords/
├── src/
│   ├── Mecalux.OrderingWords.Api/          # 🌐 Web API Layer
│   │   ├── Controllers/                     # API Controllers
│   │   ├── Middleware/                      # Global middleware
│   │   ├── Models/                          # Request/Response DTOs
│   │   └── Properties/                      # Launch settings
│   ├── Mecalux.OrderingWords.Application/   # 💼 Business Logic Layer
│   │   ├── Services/                        # Business services
│   │   ├── Contracts/                       # Interfaces
│   │   └── Enums/                          # Domain enums
│   ├── Mecalux.OrderingWords.Domain/        # 🏛️ Domain Layer
│   │   └── Entities/                        # Domain entities
│   └── Mecalux.OrderingWords.Infrastructure/ # 🔧 Infrastructure Layer
│       ├── Repository/                      # Data access
│       └── Helpers/                         # Utility classes
├── test/
│   └── Mecalux.OrderingWords.test/          # 🧪 Unit Tests
├── ui/
│   └── OrderingWords/                       # 🎨 Angular Frontend
└── logs/                                    # 📋 Application logs
```

## 🔧 Configuration

### **Environment Variables**
- `ASPNETCORE_ENVIRONMENT`: Development/Production
- **Logging Levels**: Configurable via `appsettings.json`
- **CORS Origins**: Restricted to `localhost:4200` in development

### **Logging**
- **Console**: Structured JSON logging
- **File**: Daily rolling logs in `/logs` directory
- **Retention**: 7 days of log files

## 🤝 Contributing

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

## 📋 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

**Built with ❤️ using Clean Architecture principles and modern development practices.**