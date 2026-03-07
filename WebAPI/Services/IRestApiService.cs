using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IMeetEventService
    {
        // Account
        Task<Account> GetOrCreateAccountAsync(string email);
        Task<Account> GetAccountByIdAsync(long accountId);
        Task<Account> UpdateAccountAsync(Account acc);
        Task<bool> DeleteAccountAsync(long? accountId);

        // Post
        Task<Post> CreatePostAsync(string text, string imageUrl, long accountId);
        Task<List<Post>> GetPostsByAccountAsync(long? accountId);
        Task<bool> DeletePostAsync(long? postId);

        // Event
        Task<Meeting> CreateEventAsync(Eventing _event, long accountId, long roleId = 1);
        Task<List<Eventing>> GetAllLegalEventsAsync(long? accountId);
        Task<List<Eventing>> GetAllAccountsIvents(long accountId);
        Task<bool> UpdateEventStage(long eventId, long stageId);
        Task<Eventing> GetEventByIdEvent(long eventId);
        Task<Account> GetAccountByEventIdAsync(long eventId);
        Task<bool> JoinEventAsParticipant(long accountId, long eventId);
        Task<bool> IsAccountConnectedToEvent(long accountId, long eventId);
        Task<List<(Account, Meeting)>> GetAllAccountsInEvent(long eventId);

        // Message
        Task<List<Message>> GetAllMessagesByEventId(long eventId);
        Task<bool> CreateMessage(string text, long eventId, long accountId);

        // Other
        Task<int> GetCountMeetEvents(long? accountId);
        Task<int> GetCountCreateEvents(long? accountId);
        Task<bool> TestConnectionAsync();



    }

    public class MeetEventService : IMeetEventService
    {
        private readonly MeetEventDBContext _context;
        private readonly ILogger<MeetEventService> _logger;

        public MeetEventService(MeetEventDBContext context, ILogger<MeetEventService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                _logger.LogInformation("🔄 Проверяем подключение к MySQL...");
                var canConnect = await _context.Database.CanConnectAsync();
                _logger.LogInformation(canConnect ? "✅ Подключение успешно!" : "❌ Не удалось подключиться");
                return canConnect;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Ошибка: {ex.Message}");
                return false;
            }
        }


        public Task<Meeting> CreateEventAsync(Eventing _event, long accountId, long roleId = 1)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateMessage(string text, long eventId, long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> CreatePostAsync(string text, string imageUrl, long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccountAsync(long? accountId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(long? postId)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByEventIdAsync(long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByIdAsync(long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<(Account, Meeting)>> GetAllAccountsInEvent(long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Eventing>> GetAllAccountsIvents(long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Eventing>> GetAllLegalEventsAsync(long? accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetAllMessagesByEventId(long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountCreateEvents(long? accountId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountMeetEvents(long? accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Eventing> GetEventByIdEvent(long eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetOrCreateAccountAsync(string email)
        {
            try
            {
                _logger.LogInformation($"🔍 Ищем аккаунт: {email}");

                // Ищем существующий
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.email == email);

                if (existingAccount != null)
                {
                    _logger.LogInformation($"✅ Аккаунт найден: {existingAccount.id}");
                    return existingAccount;
                }

                // Создаем новый
                _logger.LogInformation($"🆕 Создаем новый аккаунт для: {email}");

                var newAccount = new Account
                {
                    email = email,
                    created_at = DateTime.UtcNow,
                    f_name = "",
                    s_name = "",
                    count_value = 0
                };

                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"✅ Новый аккаунт создан! ID: {newAccount.id}");
                return newAccount;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Ошибка: {ex.Message}");
                throw;
            }
        }

        public Task<List<Post>> GetPostsByAccountAsync(long? accountId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAccountConnectedToEvent(long accountId, long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> JoinEventAsParticipant(long accountId, long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Account> UpdateAccountAsync(Account acc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventStage(long eventId, long stageId)
        {
            throw new NotImplementedException();
        }
    }
}
