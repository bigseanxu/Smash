
#import <UIKit/UIKit.h>

@interface SocialViewController : UIViewController
- (int) shareWithFacebook: (NSString *)title message:(NSString *)message;
- (int) shareWithTwitter: (NSString *)title message:(NSString *)message;
@end
