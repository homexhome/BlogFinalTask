using BlogFinalTask.Data.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogFinalTask.Services.Helpers
{
    public class ErrorLogger
    {
        private IRepositoryCollection _repo;
        private NavigationManager _navigationManager;
        private IHttpContextAccessor _httpContextAccessor;

        public ErrorLogger(IRepositoryCollection repo, NavigationManager navigationManager, IHttpContextAccessor httpContextAccessor) {
            _repo = repo;
            _navigationManager = navigationManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetClientIPAddress() {
            var connection = _httpContextAccessor?.HttpContext?.Connection;
            var remoteIpAddress = connection?.RemoteIpAddress;

            var forwardedFor = _httpContextAccessor?.HttpContext?.Request.Headers["X-Forwarded-For"];
            if (!string.IsNullOrEmpty(forwardedFor)) {
                var ips = forwardedFor?.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (ips?.Length > 0) {
                    if (IPAddress.TryParse(ips[0], out var forwardedIp)) {
                        remoteIpAddress = forwardedIp;
                    }
                }
            }
            return remoteIpAddress?.ToString();
        }

        public void LogNoContentError() {
            _repo.logger.LogDebug(1, $"No Content Error was throw on {DateTime.UtcNow}" +
                $" error path was on {_navigationManager.Uri}");
            var clientIP = GetClientIPAddress();
            if (clientIP is not null) {
                _repo.logger.LogDebug(1, $"IP Address of user that initialized connection was {clientIP}");
            }
        }
        public void LogAccesDeniedError() {
            _repo.logger.LogDebug(1, $"Access Denied Error was throw on {DateTime.UtcNow}" +
                $" error path was on {_navigationManager.Uri}");
            var clientIP = GetClientIPAddress();
            if (clientIP is not null) {
                _repo.logger.LogDebug(1, $"IP Address of user that initialized connection was {clientIP}");
            }
        }
    }
}
