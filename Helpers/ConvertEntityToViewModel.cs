using System.Collections.Generic;
using System.Linq;
using vocabteam.Models.Entities;
using vocabteam.Models.ViewModels;

namespace vocabteam.Helpers
{
    public class ConvertEntityToViewModel
    {
        // public static UserResponse convert_UserEntity_UserResponse(User u)
        // {
        //     return new UserResponse
        //     {
        //         Username = u.Username,
        //         Email = u.Email,
        //         AvatarUrl = u.AvatarUrl,
        //         UserRoles = convertUserRoleEntityToUserRoleResponse(u.UserRoles.AsQueryable())
        //     };
        // }
        // public static UserRoleResponse convertUserRoleEntityToUserRoleResponse(UserRole u)
        // {
        //     return new UserRoleResponse
        //     {
        //         UserId = u.UserId,
        //         RoleId = u.RoleId
        //     };
        // }
        // public static List<UserResponse> convertUserEntityToUserResponse(IQueryable<User> users)
        // {
        //     List<UserResponse> usersList = new List<UserResponse>();
        //     foreach (var u in users)
        //     {
        //         usersList.Add(convertUserEntityToUserResponse(u));
        //     }
        //     return usersList;
        // }        
        // public static List<UserRoleResponse> convertUserRoleEntityToUserRoleResponse(IQueryable<UserRole> user_roles)
        // {
        //     List<UserRoleResponse> user_rolesList = new List<UserRoleResponse>();
        //     foreach (var u in user_roles)
        //     {
        //         user_rolesList.Add(convertUserRoleEntityToUserRoleResponse(u));
        //     }
        //     return user_rolesList;
        // }
    }
}