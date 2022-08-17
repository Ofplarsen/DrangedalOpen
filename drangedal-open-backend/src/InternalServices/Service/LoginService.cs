using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Common.Exceptions;
using InternalServices.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
namespace InternalServices.Service;

public class LoginService : ILoginService
{


}