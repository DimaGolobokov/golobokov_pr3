using golobokov_pr3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golobokov_pr3
{
    internal class Helper
    {
        private static InsuranceMedicalCompanyDBEntities _context; // Создание статичной приватной переменной, для обращения к контексту модели данных

        // Метод (публичный, чтобы к нему можно было обращаться из любой части программы)
        // получения контекста данных, необходимый для создания подключения к БД
        public static InsuranceMedicalCompanyDBEntities GetContext()
        {
            // Условие при котором проверяется, что если подключение не установлено, то необходимо создать новое подключение
            if (_context == null)
            {
                _context = new InsuranceMedicalCompanyDBEntities(); // Создание нового подключения к БД
            }
            return _context; // возвращение подключения
        }
    }
}
