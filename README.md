# FileSystemImage
A program which scans a volume and creates a virtual copy containing metadata of every file and folder. 
The object structure can be serialized and deserialized to disk, compressed and encrypted very fast even for +1 million file volumes using 
my own LMAZ2 algorithm which is based upon the converted c code written by the creators of 7zip. My version uses multithreaded compression and encryption streams. Its hardcoded to use the maximum compression ratio and not be heavy on memory usage to achive the same performance as the latest 7zip c++ implementation. 

Its use case is if you want a saved state over a disks filestructure for keeping a record on what was on the disk if you would have the data lost. 
No 2, the most usefull feature is the ability to search for a file or files with either wildcard or regular expression. With an optional folder matching search functionality if you are only interested in searching in a specific folder anywhere on the filesystem. For instance in all bin folders regardles of the root folder. Single Root folder is also possible depending on how the search string looks like.

Search results are in most cases returned almost emidiatly compared to windows search which is really slow. Since the search is always done with regular expression as the wildcard search strings are converted to regex before doing a search.
Very complex or overly complicated regular expression search patterns can take a long time to complete but the ability to cancel is done async just as the search and will stop emidietly if the user presses the cancel button when notecing that the search is taking longer then a few seconds.
