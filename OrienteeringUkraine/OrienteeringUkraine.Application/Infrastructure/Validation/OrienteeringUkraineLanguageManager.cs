using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.Validation
{
    public class OrienteeringUkraineLanguageManager : LanguageManager
    {
        public OrienteeringUkraineLanguageManager() : base()
        {
            AddTranslation("en", "IsTakenValidator", "{PropertyName} '{PropertyValue}' is already taken");
            AddTranslation("ru", "IsTakenValidator", "{PropertyName} '{PropertyValue}' уже используется");
            AddTranslation("ua", "IsTakenValidator", "{PropertyName} '{PropertyValue}' Вже використовується");

            AddTranslation("en", "NotExistsValidator", "Entity with id = {PropertyValue} is not exists");
            AddTranslation("ru", "NotExistsValidator", "Сущность с id = {PropertyValue} не существует");
            AddTranslation("ua", "NotExistsValidator", "Сутність з id = {PropertyValue} не існує");

            AddTranslation("en", "ConfirmPasswordValidator", "Passwords do not match");
            AddTranslation("ru", "ConfirmPasswordValidator", "Пароли не совпадают");
            AddTranslation("ua", "ConfirmPasswordValidator", "Поролі не співпадають");
        }
    }
}
