# Changelog

## [2.0.3.0] 
### Added
- Visualization tools: Code Co-Occurrence Matrix and File Code Matrix.
- Search and move features in the code hierarchy.
- Add ability to drag-n-drop the codes in text editing or word processing programs.
- The user can comment on pictures in Word document and the pictures are shown in DataExtract list in a similar way to text data
- A progress bar to have a better UX of analysis

### Changed
- Fixed automatic backup so that it only saves the code hierarchy file when there are changes in the hierarchy.
- Improved code statistics calculation performance
- The GUI is not blocked when doing the analysis (implementing a BackgroundWorker)
