using Data.Entities.Models;
using Domain.Repositories;

public class CommentService
{
    private readonly CommentRepository _commentRepository;
    private readonly UserRepository _userRepository;
    private readonly FileRepository _fileRepository;

    public CommentService(CommentRepository commentRepository, UserRepository userRepository, FileRepository fileRepository)
    {
        _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
    }

    public List<Comment> GetCommentsForFile(int fileId)
    {
        return _commentRepository.GetByFileId(fileId);
    }

    public bool AddCommentToFile(int fileId, int userId, string content)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
        {
            return false;
        }

        var file = _fileRepository.GetById(fileId);
        if (file == null)
        {
            return false;
        }

        var comment = new Comment
        {
            FileId = fileId,
            UserId = userId,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _commentRepository.Add(comment);
        return true;
    }

    public bool UpdateComment(int commentId, int userId, string newContent)
    {
        var comment = _commentRepository.GetById(commentId);
        if (comment != null && comment.UserId == userId)
        {
            comment.Content = newContent;
            comment.UpdatedAt = DateTime.UtcNow;
            _commentRepository.Update(comment);
            return true;
        }
        return false;
    }

    public bool DeleteComment(int commentId, int userId)
    {
        var comment = _commentRepository.GetById(commentId);
        if (comment == null)
        {
            return false;
        }

        if (comment.UserId != userId)
        {
            return false;
        }

        _commentRepository.Delete(comment);
        return true;
    }

    public List<Comment> GetCommentsByFileId(int fileId)
    {
        var comments = _commentRepository.GetByFileId(fileId);
        return comments ?? new List<Comment>();
    }
}
