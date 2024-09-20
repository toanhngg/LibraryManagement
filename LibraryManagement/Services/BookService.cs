using Grpc.Core;
using LibraryManagement.Protos;

namespace LibraryManagement.Services
{
    public class BookService : BookRPC.BookRPCBase
    {
        private readonly ILogger<BookService> _logger;
        public BookService(ILogger<BookService> logger)
        {
            _logger = logger;
        }

        public override Task<GetBookReply> GetBookDetail(GetBookRequest request, ServerCallContext context)
        {
            var manufactors = new List<Manufactor>()
            {
                new Manufactor { Id = "1", Name = "NXB Tiền phong", Level ="Thiếu nhi"},
                new Manufactor { Id = "2", Name = "NXB Giáo dục", Level ="Giáo dục"}

            };
            return Task.FromResult(new GetBookReply
            {
                Id = request.Id,
                Name = "Sách thiếu nhi",
                Level = "Thiếu nhi",
                Manufactors = {manufactors}
            });
        }
    }
}
