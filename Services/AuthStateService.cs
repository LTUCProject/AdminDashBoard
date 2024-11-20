using System;
using System.Collections.Generic;
using Microsoft.JSInterop;

namespace Admin.Services
{
    public class AuthStateService
    {
        private readonly IJSRuntime _jsRuntime;

        public event Action OnChange;

        private bool _isLoggedIn;
        private List<string> _roles = new List<string>(); // Store roles here

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                  
                }
            }
        }


        public List<string> Roles
        {
            get => _roles;
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                   
                }
            }
        }

    }
}
