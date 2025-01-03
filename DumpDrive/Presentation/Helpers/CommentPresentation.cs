using Domain.Repositories;
using Domain.Services;
using System;

namespace Presentation
{
    public class CommentPresentation
    {
        private readonly CommentService _commentService;
        private readonly UserRepository _userRepository;

        public CommentPresentation(CommentService commentService, UserRepository userRepository)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
        }

        
        public void ShowComments(int fileId)
        {
            var comments = _commentService.GetCommentsForFile(fileId);
            if (comments == null || !comments.Any())
            {
                Console.WriteLine("There are no comments for this file.");
                Console.ReadLine();
                return;
            }

            foreach (var comment in comments)
            {
                if (_userRepository == null)
                {
                    Console.WriteLine("Error: _userRepository is not initialized.");
                    Console.ReadLine();
                    return;
                }

                var user = _userRepository.GetById(comment.UserId);

                if (user == null)
                {
                    Console.WriteLine($"User with ID: {comment.UserId} was not found.");
                    Console.ReadLine();
                    continue; 
                }

                string formattedDate = comment.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine($"{comment.UserId} - {user.Email} - {formattedDate}");
                Console.WriteLine($"Content: {comment.Content}");
                Console.ReadLine();
            }
        }

        public void AddComment(int userId, int fileId)
        {
            Console.WriteLine("Enter the content of the comment:");
            string content = Console.ReadLine();

            _commentService.AddCommentToFile(fileId, userId, content);
            Console.WriteLine("Comment successfully added.");
            Console.ReadLine();
        }

        public void UpdateComment(int commentId, int userId)
        {
            Console.WriteLine("Enter the new content of the comment:");
            string newContent = Console.ReadLine();
            try
            {
                _commentService.UpdateComment(commentId, userId, newContent);
                Console.WriteLine("Comment successfully updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }

        
        public void DeleteComment(int commentId, int userId)
        {
            try
            {
                _commentService.DeleteComment(commentId, userId);
                Console.WriteLine("Comment successfully deleted.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}