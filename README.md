# Necklace

If you use Sparkle (or some variant of it), and you have ever wondered: couldn't this be easier - then join the discussion - I value your input and perspective, it doesn't matter if you are a one man dev shop or hundreds of devs.  Your perspective matters.  

You can read more about the idea and goals by [joining the discussion](https://github.com/johncclayton/Necklace/discussions/3).
c

# Services

## ReleaseService
This handles read/write requests for your releases and channels.  You can adjust any release attribute, create a new release, move releases to different channels and so on using this service.  

In response to changes - the ReleaseService will re-generate signatures and update as required.