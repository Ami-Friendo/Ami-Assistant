using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Arguments
{
    public interface IArgument
    {
        string Name { get; } // имя аргумента
        string FriendlyName { get; set; } // имя аргумента, исользуется для локализации 
        string Description { get; } // описание аргумента
        string ExamplesInput { get; } // примеры входящих значений, которые точно работают и прописаны в parseValue,
                                      // перечислять через \n
        string ExampleOutput { get; } // вид выходного значения (value)
        string Value { get; } // значение аргумента

        bool IsRequired { get; } // является ли аргумент обязательным, если да - то необходимо что бы пользователь ввел значение
                                 // если нет - используется дефолтное значение, либо переменная среды

        bool parseValue(string inputValue); // true - если обработка прошла успешно
    }
}
