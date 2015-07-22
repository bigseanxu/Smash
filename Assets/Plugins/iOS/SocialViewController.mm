
#import "SocialViewController.h"
#import <Social/Social.h>

extern "C" {
    int shareWithFacebook(const char *title, const char *message);
    int shareWithTwitter(const char *title, const char *message);
}

int shareWithFacebook(const char *title, const char *message)
{
    SocialViewController *social = [[SocialViewController alloc] init];
    [social shareWithFacebook: [NSString stringWithUTF8String:title]
                      message:[NSString stringWithUTF8String:message]];
    return (0);
}

int shareWithTwitter(const char *title, const char *message)
{
    SocialViewController *social = [[SocialViewController alloc] init];
    [social shareWithTwitter: [NSString stringWithUTF8String:title]
                     message:[NSString stringWithUTF8String:message]];
    return (0);
}


@implementation SocialViewController
#pragma mark - Action Methods
- (int) shareWithFacebook: (NSString *)title message:(NSString *)message{
    printf("sharewithfacebook inside");
    if([SLComposeViewController isAvailableForServiceType:SLServiceTypeFacebook]) {
        SLComposeViewController *controller = [SLComposeViewController composeViewControllerForServiceType:SLServiceTypeFacebook];
        [controller setInitialText:message];
        UIViewController *current = [self getCurrentVC];
        [current presentViewController:controller animated:YES completion:Nil];
    }
    
    return(0);
}

- (int) shareWithTwitter: (NSString *)title message:(NSString *)message{
    if([SLComposeViewController isAvailableForServiceType:SLServiceTypeTwitter]) {
        SLComposeViewController *controller = [SLComposeViewController composeViewControllerForServiceType:SLServiceTypeTwitter];
        
        [controller setInitialText:message];
        
        UIViewController *current = [self getCurrentVC];
        [current presentViewController:controller animated:YES completion:Nil];
    }
    
    return(0);
}

- (UIViewController *)getCurrentVC
{
    UIViewController *result = nil;
    
    UIWindow * window = [[UIApplication sharedApplication] keyWindow];
    if (window.windowLevel != UIWindowLevelNormal)
    {
        NSArray *windows = [[UIApplication sharedApplication] windows];
        for(UIWindow * tmpWin in windows)
        {
            if (tmpWin.windowLevel == UIWindowLevelNormal)
            {
                window = tmpWin;
                break;
            }
        }
    }
    
    UIView *frontView = [[window subviews] objectAtIndex:0];
    id nextResponder = [frontView nextResponder];
    
    if ([nextResponder isKindOfClass:[UIViewController class]])
        result = nextResponder;
    else
        result = window.rootViewController;
    
    return result;
}
@end