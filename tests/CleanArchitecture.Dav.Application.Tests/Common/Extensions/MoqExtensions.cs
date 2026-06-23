using Moq;

namespace CleanArchitecture.Dav.Application.Tests.Common.Extensions;

public static class MoqExtensions
{
   public static void VerifyAllAndNoOtherCalls<T>(this Mock<T> mock) 
   where T : class
   {
      mock.VerifyAll();
      mock.VerifyNoOtherCalls();
   }
}