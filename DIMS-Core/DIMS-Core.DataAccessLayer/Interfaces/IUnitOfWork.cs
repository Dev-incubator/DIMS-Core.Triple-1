using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ISampleRepository SampleRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IDirectionRepository DirectionRepository { get; }
        ITaskRepository TaskRepository { get; }
        IVTaskRepository VTaskRepository { get; }
        IVUserTrackRepository VUserTrackRepository { get; }
        IVUserProfileRepository VUserProfileRepository { get; }
        ITaskTrackRepository TaskTrackRepository { get; }
        IUserTaskRepository UserTaskRepository { get; }
        IVUserTaskRepository VUserTaskRepository { get; }
        ITaskStateRepository TaskStateRepository { get; }
        IVUserProgressRepository VUserProgressRepository { get; }

        Task SaveChanges();
    }
}