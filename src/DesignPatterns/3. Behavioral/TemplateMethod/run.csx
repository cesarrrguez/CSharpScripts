#load "data.csx"

// Category
DataAccessObject categoryDAO = new CategoryDAO();
categoryDAO.Run();

WriteLine();

// Product
DataAccessObject productDAO = new ProductDAO();
productDAO.Run();
