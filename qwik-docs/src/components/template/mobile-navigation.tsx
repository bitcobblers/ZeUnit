import { component$} from "@builder.io/qwik"
// import { Link } from "@builder.io/qwik-city";
// import { Logomark } from "./logo";

const MenuIcon = component$((props: any) => {
    return (
      <svg
        aria-hidden="true"
        viewBox="0 0 24 24"
        fill="none"
        strokeWidth="2"
        strokeLinecap="round"
        {...props}
      >
        <path d="M4 7h16M4 12h16M4 17h16" />
      </svg>
    )
  })
  
// const CloseIcon = component$((props: any) => {
//     return (
//       <svg
//         aria-hidden="true"
//         viewBox="0 0 24 24"
//         fill="none"
//         strokeWidth="2"
//         strokeLinecap="round"
//         {...props}
//       >
//         <path d="M5 5l14 14M19 5l-14 14" />
//       </svg>
//     )
//   });
  
  // eslint-disable-next-line no-empty-pattern
//   const CloseOnNavigation = component$(({ }: { close?: () => void }) => {
//     // let pathname = usePathname()
//     // let searchParams = useSearchParams()
  
//     // useEffect(() => {
//     //   close()
//     // }, [pathname, searchParams, close])
  
//     return null
//   });
  
  export default component$(() => {
    // let [isOpen, setIsOpen] = useState$(false)
    // let close = useCallback(() => setIsOpen(false), [setIsOpen])
  
    // function onLinkClick(event: any) {
    //   let link = event.currentTarget
    //   if (
    //     link.pathname + link.search + link.hash ===
    //     window.location.pathname + window.location.search + window.location.hash
    //   ) {
    //     close()
    //   }
    // }
    
    return (
      <>
        <button
          type="button"
        //   onClick$={() => setIsOpen(true)}
          class="relative"
          aria-label="Open navigation"
        >
          <MenuIcon class="h-6 w-6 stroke-slate-500" />
        </button>        
          {/* <CloseOnNavigation close={close$} />         */}
          {/* <CloseIcon class="h-6 w-6 stroke-slate-500" /> */}
        {/* <Dialog
          open={isOpen}
          onClose={() => close()}
          class="fixed inset-0 z-50 flex items-start overflow-y-auto bg-slate-900/50 pr-10 backdrop-blur lg:hidden"
          aria-label="Navigation"
        >
          <Dialog.Panel class="min-h-full w-full max-w-xs bg-white px-4 pb-12 pt-5 sm:px-6 dark:bg-slate-900">
            <div class="flex items-center">
              <button
                type="button"
                onClick$={() => close()}
                aria-label="Close navigation"
              >
                <CloseIcon class="h-6 w-6 stroke-slate-500" />
              </button>
              <Link href="/" class="ml-6" aria-label="Home page">
                <Logomark class="h-9 w-9" />
              </Link>
            </div>
            <Navigation class="mt-5 px-1" onLinkClick={onLinkClick} />
          </Dialog.Panel>
        </Dialog> */}
      </>
    )
  });
  