using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using CoffeeShare.Infrastructure.Services.Interfaces;

namespace CoffeeShare.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> GetAllCommentsForRecipe(int recipeId)
        {
            var comments = await _commentRepository.GetAllCommentsForRecipe(recipeId);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task CreateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.CreateComment(comment);
        }

        public async Task DeleteCoffee(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.DeleteCoffee(comment);
        }
    }
}
