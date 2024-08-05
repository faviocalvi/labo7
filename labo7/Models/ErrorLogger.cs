using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo7.Models;
public class ErrorLogger
{
    private Stack<string> _errorStack = new Stack<string>();

    public void LogError(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _errorStack.Push($"{timestamp}: {message}");
    }

    public IEnumerable<string> GetAllErrors()
    {
        return _errorStack;
    }

    public void ClearErrors()
    {
        _errorStack.Clear();
    }
}
